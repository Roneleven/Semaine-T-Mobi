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
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI_MENU-Button");
        Time.timeScale = 1;
    }
}
