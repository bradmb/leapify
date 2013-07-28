using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LeapMotion.Gestures
{
    public delegate void LeapMessageHandler(string message);

    public delegate void LeapActionHandler();

    public partial class GestureController : Listener
    {
        #if DEBUG
        public event LeapMessageHandler OnMessage;
        #endif

        #region Public Access Variables
        /// <summary>
        /// The event called when a left swipe is successful
        /// </summary>
        public event LeapActionHandler OnSwipeLeft;

        /// <summary>
        /// The event called when a right swipe is successful
        /// </summary>
        public event LeapActionHandler OnSwipeRight;

        /// <summary>
        /// The event called when a swipe up is successful
        /// </summary>
        public event LeapActionHandler OnSwipeUp;

        /// <summary>
        /// The event called when a swipe down is successful
        /// </summary>
        public event LeapActionHandler OnSwipeDown;

        /// <summary>
        /// The event called when a screen tap is successful
        /// </summary>
        public event LeapActionHandler OnScreenTap;

        /// <summary>
        /// The event called when a clockwise circle is successful
        /// </summary>
        public event LeapActionHandler OnCircleClockwise;

        /// <summary>
        /// The event called when a counterclockwise circle is successful
        /// </summary>
        public event LeapActionHandler OnCircleCounterclockwise;

        /// <summary>
        /// The event called when a device connects
        /// </summary>
        public event LeapActionHandler OnLeapConnection;

        /// <summary>
        /// The amount of fingers required for a swipe to be approved
        /// </summary>
        public int SwipeFingersRequired { get; set; }

        /// <summary>
        /// The amount of fingers required for a tap to be approved
        /// </summary>
        public int TapFingersRequired { get; set; }

        /// <summary>
        /// The amount of tools (non-fingers) required for a swipe to be approved
        /// </summary>
        public int SwipeToolsRequired { get; set; }

        /// <summary>
        /// The amount of tools (non-fingers) required for a tap to be approved
        /// </summary>
        public int TapToolsRequired { get; set; }

        /// <summary>
        /// The amount of distance from start to end for a swipe to be approved
        /// </summary>
        public int DistanceRequired { get; set; }

        /// <summary>
        /// The amount of speed required for a swipe to be approved
        /// </summary>
        public int SpeedRequired { get; set; }

        /// <summary>
        /// The delay after an action is completed before we start tracking for new actions
        /// </summary>
        public int TimeBeforeNextAction { get; set; }
        #endregion

        #region Action Tracking Variables
        private bool _currentlyTracking;
        private Gesture.GestureType _currentlyTrackingType;
        private int _currentActionFingers;
        private int _currentActionTools;
        private int _currentActionHands;
        #endregion

        #region System Variables
        private int _visibleFingers;
        private int _visibleTools;
        private int _visibleHands;
        private DateTime _lastGestureEvent;
        #endregion

        #if DEBUG
        private void SendDebugMessage(string message)
        {
            if (OnMessage != null)
            {
                OnMessage(message);
            }
        }

        public override void OnInit(Controller controller)
        {
            SendDebugMessage("Initialized");
        }
        #endif

        public override void OnConnect(Controller controller)
        {
            // This lets anyone subscribed know that a device connected
            if (OnLeapConnection != null)
            {
                OnLeapConnection();
            }

            // If this was not enabled, we'd have to keep the program in the foreground
            controller.SetPolicyFlags(Controller.PolicyFlag.POLICYBACKGROUNDFRAMES);

            // We're using all the gestures in one way or another
            controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESWIPE);

            #if DEBUG
            SendDebugMessage("Connected");
            #endif

        }

        #if DEBUG
        public override void OnDisconnect(Controller controller)
        {
            SendDebugMessage("Disconnected");
        }
        #endif

        #if DEBUG
        public override void OnExit(Controller controller)
        {
            SendDebugMessage("Exited");
        }
        #endif

        /// <summary>
        /// Called many (many) times a second. This system handles all gesture actions and responses
        /// </summary>
        /// <param name="controller"></param>
        public override void OnFrame(Controller controller)
        {
            var frame = controller.Frame();
            var gestures = frame.Gestures();

            // Grab the current count of objects that the device
            // can see and store that data for later use
            _visibleFingers = frame.Fingers.Count();
            _visibleTools = frame.Tools.Count();
            _visibleHands = frame.Hands.Count();

            #if DEBUG
            SendDebugMessage("Fingers: " + _visibleFingers);
            SendDebugMessage("Tools: " + _visibleTools);
            SendDebugMessage("Hands: " + _visibleHands);
            #endif
            
            // If we're not currently tracking any gestures in this frame, do a cleanup check and don't continue on
            if (!gestures.Any() || (_lastGestureEvent != DateTime.MinValue && DateTime.Now < _lastGestureEvent.AddMilliseconds(TimeBeforeNextAction)))
            {
                if ((DateTime.Now - _lastGestureEvent).TotalSeconds > 2 && _currentlyTracking) {
                    _currentlyTracking = false;
                    _currentlyTrackingType = Gesture.GestureType.TYPEINVALID;

                    #if DEBUG
                    SendDebugMessage("Idle Device - Resetting gestures");
                    #endif
                }

                return;
            }

            // If there's no gesture in progress, make sure our active counts are set to zero
            if (!_currentlyTracking)
            {
                _currentActionFingers = 0;
                _currentActionTools = 0;
            }
            else
            {
                // Else set all our active counts to the highest amount of objects there are for each type
                if (_currentActionFingers < _visibleFingers)
                {
                    _currentActionFingers = _visibleFingers;
                }

                if (_currentActionTools < _visibleTools)
                {
                    _currentActionTools = _visibleTools;
                }

                if (_currentActionHands < _visibleHands)
                {
                    _currentActionHands = _visibleHands;
                }
            }

            // There may be many, but we only care about the first.
            var thisGesture = gestures.First();

            switch (thisGesture.Type)
            {
                case Gesture.GestureType.TYPESWIPE:
                    var swipe = new SwipeGesture(thisGesture);
                    ProcessSwipe(swipe); // Swipe.cs
                    break;
                case Gesture.GestureType.TYPESCREENTAP:
                    var screenTap = new ScreenTapGesture(thisGesture);
                    ProcessScreenTap(screenTap); // Tap.cs
                    break;
                case Gesture.GestureType.TYPEKEYTAP:
                    var keyTap = new KeyTapGesture(thisGesture);
                    ProcessKeyTap(keyTap); // Tap.cs
                    break;
                case Gesture.GestureType.TYPECIRCLE:
                    var circle = new CircleGesture(thisGesture);
                    ProcessCircle(circle); // Circle.cs
                    break;
            }
        }
    }
}
