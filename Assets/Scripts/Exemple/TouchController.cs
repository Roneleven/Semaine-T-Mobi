using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch; //Le using pour LeanTouch
using Lofelt.NiceVibrations; //Le using pour Nice Vibrations
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    public bool debugTouch;
    public bool debugGyro;

    public Toggle touchToggle;
    public Toggle gyroToggle;

    private GameController _gameController;
    protected GameController gameController
    {
        get
        {
            if (_gameController != null)
            {
                return _gameController;
            }
            else
            {
                _gameController = GameController.Instance as GameController;
            }
            return _gameController;
        }

        set
        {
            _gameController = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Attach nos fonction custom au events de lean touch
        LeanTouch.OnFingerDown += OnFingerDown;
        LeanTouch.OnFingerUpdate += OnFingerHold;
        LeanTouch.OnFingerUp += OnFingerUp;

        Input.gyro.enabled = true; //Pas utile pour iOS, mais important pour Android
    }

    private void OnDestroy()
    {
        //Detach nos fonctions custom au events de lean touch, pour evitez les null ref aprés le destroy de l'objet
        // Warning !!!! C'est essentiel, il faut le faire dans tout les cas !
        LeanTouch.OnFingerDown -= OnFingerDown;
        LeanTouch.OnFingerUpdate -= OnFingerHold;
        LeanTouch.OnFingerUp -= OnFingerUp;
    }

    void OnFingerDown(LeanFinger finger)
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
        print("ttt");

        if (debugTouch)
        {
            print("Finger is down at " + finger.ScreenPosition);
        }
    }

    void OnFingerHold(LeanFinger finger)
    {
        if (debugTouch)
        {
            print("Finger is held at " + finger.ScreenPosition + " it started at " + finger.StartScreenPosition);
        }
    }

    void OnFingerUp(LeanFinger finger)
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.HeavyImpact);

        if (debugTouch)
        {
            print("Finger is up at " + finger.ScreenPosition + "It traveled a total of " + Vector2.Distance(finger.StartScreenPosition, finger.ScreenPosition) + " pixels");
        }
    }

    private void Update()
    {
        debugTouch = touchToggle.isOn;
        debugGyro = gyroToggle.isOn;

        GyroscopeInputRoutine();
    }

    void GyroscopeInputRoutine()
    {
        Vector3 gyroValue = Input.gyro.attitude.eulerAngles;
        Quaternion gyroRawValue = Input.gyro.attitude;
        gameController.ChangeGyroDebugRot(gyroRawValue);

        if(debugGyro)
        {
            print("Gyro euler value = " + gyroValue + " Gyro quater value = " + gyroRawValue);
        }
    }
}
