using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class basicInputs : MonoBehaviour
{
    public GameObject panel;
    bool paused;


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
            paused = !paused;
            panel.SetActive(paused);
        }
    }

    public void GoToMenu()
    {
        Debug.Log("Pressed");
        SceneManager.LoadScene("MainMenu");
    }
}
