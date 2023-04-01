using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Lean.Touch
{
    [HelpURL(LeanTouch.HelpUrlPrefix + "LeanTouchEvents")]
    [AddComponentMenu(LeanTouch.ComponentPathPrefix + "Touch Events")]
    public class LeanTouchEvents : MonoBehaviour
    {
        [System.Serializable] public class LeanFingerEvent : UnityEvent<LeanFinger> { }

        [SerializeField] private LeanFingerEvent fingerDownEvent;
        [SerializeField] private LeanFingerEvent fingerUpEvent;
        [SerializeField] private LeanFingerEvent fingerTapEvent;

        protected virtual void OnEnable()
        {
            LeanTouch.OnFingerDown += HandleFingerDown;
            LeanTouch.OnFingerUp += HandleFingerUp;
            LeanTouch.OnFingerTap += HandleFingerTap;
        }

        protected virtual void OnDisable()
        {
            LeanTouch.OnFingerDown -= HandleFingerDown;
            LeanTouch.OnFingerUp -= HandleFingerUp;
            LeanTouch.OnFingerTap -= HandleFingerTap;
        }

        public void HandleFingerDown(LeanFinger finger)
        {
            if (fingerDownEvent != null)
            {
                fingerDownEvent.Invoke(finger);
            }
        }

        public void HandleFingerUp(LeanFinger finger)
        {
            if (fingerUpEvent != null)
            {
                fingerUpEvent.Invoke(finger);
            }
        }

        public void HandleFingerTap(LeanFinger finger)
        {
            if (fingerTapEvent != null)
            {
                fingerTapEvent.Invoke(finger);
            }
        }

        public void HandleFingerUpdate(LeanFinger finger)
        {
            Debug.Log("Finger " + finger.Index + " is still touching the screen");
        }

        public void HandleFingerSwipe(LeanFinger finger)
        {
            Debug.Log("Finger " + finger.Index + " swiped the screen");
        }

        public void HandleGesture(List<LeanFinger> fingers)
        {
            Debug.Log("Gesture with " + fingers.Count + " finger(s)");
            Debug.Log("    pinch scale: " + LeanGesture.GetPinchScale(fingers));
            Debug.Log("    twist degrees: " + LeanGesture.GetTwistDegrees(fingers));
            Debug.Log("    twist radians: " + LeanGesture.GetTwistRadians(fingers));
            Debug.Log("    screen delta: " + LeanGesture.GetScreenDelta(fingers));
        }
    }
}
