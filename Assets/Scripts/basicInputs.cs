using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class basicInputs : MonoBehaviour
{
    public GameObject panel;
    bool paused;
    public GameObject controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paused = false;
        panel.SetActive(paused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GoToMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
            Debug.Log("Escape pressed");
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Going to main menu");
    }

    public void Resume()
    {
        if (paused)
        {
            TogglePause();
            Debug.Log("Resuming");
        }
    }

    private void TogglePause()
    {
        paused = !paused;
        panel.SetActive(paused);

        controller.GetComponent<FirstPersonController>().lockCursor = !controller.GetComponent<FirstPersonController>().lockCursor;
        controller.GetComponent<FirstPersonController>().playerCanMove = !controller.GetComponent<FirstPersonController>().playerCanMove;
        controller.GetComponent<FirstPersonController>().cameraCanMove = !controller.GetComponent<FirstPersonController>().cameraCanMove;
    }
}
