using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LeapMotion.Gestures
{
    public partial class GestureController
    {
        private void ProcessSwipe(SwipeGesture swipe)
        {
            if (swipe.State == Gesture.GestureState.STATESTART && !_currentlyTracking)
            {
                _currentlyTracking = true;
                _currentlyTrackingType = swipe.Type;
                _currentActionFingers = 0;
                _currentActionTools = 0;

                #if DEBUG
                SendDebugMessage(string.Format("Swipe Start (posX:{0} posY:{1} fing:{2} tool:{3})", swipe.Position.x, swipe.Position.y, _visibleFingers, _visibleTools));
                #endif
            }
            else if (swipe.State == Gesture.GestureState.STATESTOP && _currentlyTracking && _currentlyTrackingType == swipe.Type)
            {
                _currentlyTracking = false;

                if (_currentActionFingers != SwipeFingersRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- invalid finger count");
                    #endif
                    
                    return;
                }
                else if (_currentActionTools != SwipeToolsRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- invalid tool count");
                    #endif
                    
                    return;
                } else if (swipe.Speed < SpeedRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- speed too low");
                    #endif
                    
                    return;
                } else if (swipe.StartPosition.DistanceTo(swipe.Position) < DistanceRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- distance too low");
                    #endif
                    
                    return;
                }


                if (swipe.Position.x < 0 && swipe.Direction.y > -0.5 && swipe.Direction.y < 0.5 && OnSwipeLeft != null)
                {
                    OnSwipeLeft();
                }
                else if (swipe.Position.x > 0 && swipe.Direction.y > -0.5 && swipe.Direction.y < 0.5 && OnSwipeRight != null)
                {
                    OnSwipeRight();
                }
                else if (swipe.Direction.y > 0.7 && OnSwipeUp != null)
                {
                    OnSwipeUp();
                }
                else if (swipe.Direction.y < -0.7 && OnSwipeDown != null)
                {
                    OnSwipeDown();
                }

                #if DEBUG
                SendDebugMessage(string.Format("Swipe Stop (x:{0} y:{1} dur:{2} dist:{3} speed:{4})",
                    swipe.Direction.x,
                    swipe.Direction.y,
                    swipe.DurationSeconds,
                    swipe.StartPosition.DistanceTo(swipe.Position),
                    swipe.Speed
                ));
                #endif

                _lastGestureEvent = DateTime.Now;
            }
            else if (swipe.State == Gesture.GestureState.STATEUPDATE && _currentlyTracking && _currentlyTrackingType == swipe.Type)
            {
                if (_currentActionFingers < _visibleFingers)
                {
                    _currentActionFingers = _visibleFingers;
                }

                if (_currentActionTools < _visibleTools)
                {
                    _currentActionTools = _visibleTools;
                }
            }
        }
    }
}
