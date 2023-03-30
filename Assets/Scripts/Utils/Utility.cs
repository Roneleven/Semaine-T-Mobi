using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum ENUM_Device_Type
{
    Tablet,
    Phone
}

public static class Utility
{

    /// <summary>
    /// Remap a value, from the current range, to a new range
    /// </summary>
    /// <param name="x"> Value to remap</param>
    /// <param name="in_min">Minimum value of the current range</param>
    /// <param name="in_max">Maximun value of the current range</param>
    /// <param name="out_min">Minimum value of the new range</param>
    /// <param name="out_max">Maximun value of the new range</param>
    /// <returns></returns>
    public static float MapInput(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }


    //if (GetDeviceType() == ENUM_Device_Type.Phone){}else{}
    /// <summary>
    /// Return the divecie type, either Phone or Tablet
    /// </summary>
    /// <returns></returns>
    public static ENUM_Device_Type GetDeviceType()
    {
#if UNITY_IOS
        bool deviceIsIpad = UnityEngine.iOS.Device.generation.ToString().Contains("iPad");
        if (deviceIsIpad)
        {
            return ENUM_Device_Type.Tablet;
        }
 
        bool deviceIsIphone = UnityEngine.iOS.Device.generation.ToString().Contains("iPhone");
        if (deviceIsIphone)
        {
            return ENUM_Device_Type.Phone;
        }
#endif

        float aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
        bool isTablet = DeviceDiagonalSizeInInches() > 7.2f && aspectRatio < 2f;

        if (isTablet)
        {
            return ENUM_Device_Type.Tablet;
        }
        else
        {
            return ENUM_Device_Type.Phone;
        }
    }

    //Check if tablet or phone-------------------------------------------------------
    private static float DeviceDiagonalSizeInInches()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

        return diagonalInches;
    }

    public static string GetDirectionFromAngle(float signedAngle, float permisivity)
    {
        //print(signedAngle);
        if (signedAngle > -45 + permisivity && signedAngle < 45 - permisivity)
        {
            return "up";
        }
        else if (signedAngle > 45 + permisivity && signedAngle < 135 - permisivity)
        {
            return "right";
        }
        else if (signedAngle > 135 + permisivity || signedAngle < -135 - permisivity)
        {
            return "bottom";
        }
        else if (signedAngle > -135 + permisivity && signedAngle < -45 - permisivity)
        {
            return "left";
        }
        return "null";
    }

    public static string GetMinutesAndSecond(float value)
    {
        var minutes = Mathf.FloorToInt(value / 60);
        var seconds = Mathf.FloorToInt(value % 60);
        return string.Format(minutes.ToString("00") + ":" + seconds.ToString("00"));
    }

    public static void Invoke(this MonoBehaviour mb, System.Action f, float delay)
    {
        mb.StartCoroutine(InvokeRoutine(f, delay));
    }

    private static IEnumerator InvokeRoutine(System.Action f, float delay)
    {
        yield return new WaitForSeconds(delay);
        f();
    }
}


