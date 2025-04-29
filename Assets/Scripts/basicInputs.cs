using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;


interface Interactable
{
    public void Interact();
}

public class basicInputs : MonoBehaviour
{
    public GameObject panel;
    bool paused;
    public GameObject controller;
    public ParticleSystem smoke;
    public Transform Source;
    public float Range;

    private LayerMask mask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paused = false;
        panel.SetActive(paused);
        mask = LayerMask.GetMask("Interactable");

        Time.timeScale = 1;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(Source.position, Source.forward);
            Debug.Log("E key pressed");
            if (Physics.Raycast(r, out RaycastHit hitInfo, Range, mask))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Interactable obj))
                {
                    obj.Interact();
                }
            }
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
        ToggleMovement();
    }

    private void ToggleMovement()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        controller.GetComponent<FirstPersonController>().lockCursor = !controller.GetComponent<FirstPersonController>().lockCursor;
        controller.GetComponent<FirstPersonController>().playerCanMove = !controller.GetComponent<FirstPersonController>().playerCanMove;
        controller.GetComponent<FirstPersonController>().cameraCanMove = !controller.GetComponent<FirstPersonController>().cameraCanMove;
    }
}
