using UnityEngine;
using UnityEngine.SceneManagement;

public class basicInputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Pressed");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
