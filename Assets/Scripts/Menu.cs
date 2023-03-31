using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Image imageToDisable;
    public Button buttonToDisable;

    void Start()
    {
        Time.timeScale = 0; // Pause the game at start
    }

    public void OnClick()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene("Eden Scene"); // Replace "YourSceneName" with the name of your scene
        if (imageToDisable != null) imageToDisable.gameObject.SetActive(false);
        if (buttonToDisable != null) buttonToDisable.gameObject.SetActive(false);
    }
}
