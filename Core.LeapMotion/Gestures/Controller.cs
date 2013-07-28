﻿using Leap;
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
        public event LeapActionHandler OnSwipeLeft;

        public event LeapActionHandler OnSwipeRight;

        public event LeapActionHandler OnSwipeUp;

        public event LeapActionHandler OnSwipeDown;

        public event LeapActionHandler OnScreenTap;

        public event LeapActionHandler OnCircleClockwise;

        public event LeapActionHandler OnCircleCounterclockwise;

        public event LeapActionHandler OnLeapConnection;

        public int SwipeFingersRequired { get; set; }

        public int TapFingersRequired { get; set; }

        public int SwipeToolsRequired { get; set; }

        public int TapToolsRequired { get; set; }

        public int DistanceRequired { get; set; }

        public int SpeedRequired { get; set; }

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
            if (OnLeapConnection != null)
            {
                OnLeapConnection();
            }
            controller.SetPolicyFlags(Controller.PolicyFlag.POLICYBACKGROUNDFRAMES);
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

        public override void OnFrame(Controller controller)
        {
            var frame = controller.Frame();
            var gestures = frame.Gestures();

            _visibleFingers = frame.Fingers.Count();
            _visibleTools = frame.Tools.Count();
            _visibleHands = frame.Hands.Count();

            #if DEBUG
            SendDebugMessage("Fingers: " + _visibleFingers);
            SendDebugMessage("Tools: " + _visibleTools);
            SendDebugMessage("Hands: " + _visibleHands);
            #endif
            
            var trackedGest = gestures;

            if (!trackedGest.Any() || (_lastGestureEvent != DateTime.MinValue && DateTime.Now < _lastGestureEvent.AddMilliseconds(TimeBeforeNextAction)))
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

            if (!_currentlyTracking)
            {
                _currentActionFingers = 0;
                _currentActionTools = 0;
            }
            else
            {
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

            var thisGesture = trackedGest.First();

            switch (thisGesture.Type)
            {
                case Gesture.GestureType.TYPESWIPE:
                    var swipe = new SwipeGesture(thisGesture);
                    ProcessSwipe(swipe);
                    break;
                case Gesture.GestureType.TYPESCREENTAP:
                    var screenTap = new ScreenTapGesture(thisGesture);
                    ProcessScreenTap(screenTap);
                    break;
                case Gesture.GestureType.TYPEKEYTAP:
                    var keyTap = new KeyTapGesture(thisGesture);
                    ProcessKeyTap(keyTap);
                    break;
                case Gesture.GestureType.TYPECIRCLE:
                    var circle = new CircleGesture(thisGesture);
                    ProcessCircle(circle);
                    break;
            }
        }
    }
}
