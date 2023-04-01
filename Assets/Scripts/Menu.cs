using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0; // Pause the game at start
    }

    public void OnClick()
    {
        Time.timeScale = 1;
    }
}
