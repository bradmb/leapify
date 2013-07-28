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
        internal void ProcessCircle(CircleGesture circle)
        {
            if (circle.State == Gesture.GestureState.STATESTART && _visibleHands > 1)
            {
                _currentlyTracking = true;
                _currentlyTrackingType = circle.Type;
                _lastGestureEvent = DateTime.Now;

                #if DEBUG
                SendDebugMessage(string.Format("Circle Start (normX:{0} normY:{1} fing:{2} tool:{3})", circle.Normal.x, circle.Normal.y, _visibleFingers, _visibleTools));
                #endif
            }
            else if (circle.State == Gesture.GestureState.STATEUPDATE && _visibleHands > 1 && _currentlyTracking && _currentlyTrackingType == circle.Type)
            {
                if (circle.Pointable.Direction.AngleTo(circle.Normal) <= (Math.PI / 4))
                {
                    if (OnCircleClockwise != null)
                    {
                        OnCircleClockwise();
                    }
                }
                else
                {
                    if (OnCircleCounterclockwise != null)
                    {
                        OnCircleCounterclockwise();
                    }
                }

                _lastGestureEvent = DateTime.Now;

                #if DEBUG
                SendDebugMessage(string.Format("Circle Update (dir:{0} fing:{1} tool:{2})", circle.Pointable.Direction.AngleTo(circle.Normal) <= (Math.PI / 4) ? "clockwise" : "counterclockwise", _visibleFingers, _visibleTools));
                #endif
            }
            else if (circle.State == Gesture.GestureState.STATESTOP && _currentlyTracking && _currentlyTrackingType == circle.Type)
            {
                _currentlyTracking = false;

                #if DEBUG
                SendDebugMessage(string.Format("Circle Stop (normX:{0} normY:{1} fing:{2} tool:{3})", circle.Normal.x, circle.Normal.y, _visibleFingers, _visibleTools));
                #endif
            }
        }
    }
}
