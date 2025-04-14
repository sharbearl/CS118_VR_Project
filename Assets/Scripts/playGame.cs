using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playGame : MonoBehaviour
{
    public Image startImg;
    public Image quitImg;

    public void Start()
    {
        startImg.enabled = false;
        quitImg.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }

    public void ToggleStart()
    {
        startImg.enabled = !startImg.enabled;
    }

    public void ToggleQuit()
    {
        quitImg.enabled = !quitImg.enabled;
    }
}
