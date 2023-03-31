using UnityEngine;

public static class DataManager
{
    public static float highScore = 0f;

    public static void SaveData()
    {
        PlayerPrefs.SetFloat("highScore", highScore);
        PlayerPrefs.Save();
    }

    public static void LoadData()
    {
        highScore = PlayerPrefs.GetFloat("highScore", 0f);
    }
}
