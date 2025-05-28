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
    public GameObject pauseScreen;
    public GameObject interactText;
    bool paused;
    public GameObject controller;
    public Transform Source;
    public float Range;

    private LayerMask mask;
    private List<GameObject> cats = new List<GameObject>();
    private List<GameObject> catMews = new List<GameObject>();
    private GameObject kettle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("MovingCat"))
        {
            cats.Add(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("MeowingCat"))
        {
            catMews.Add(obj);
        }
        kettle = GameObject.FindWithTag("kettle");

        paused = false;
        pauseScreen.SetActive(paused);
        interactText.SetActive(false);
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

        Ray r = new Ray(Source.position, Source.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, Range, mask))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Interactable obj))
            {
                interactText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) 
                { 
                    Debug.Log("E key pressed");
                    obj.Interact();
                }
            }
            else
            {
                interactText.SetActive(false);
            }
        }
        else
        {
            interactText.SetActive(false);
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
        pauseScreen.SetActive(paused);
        ToggleMovement();

        foreach (GameObject obj in cats)
        {
            if (obj != null)
                obj.GetComponent<CatMovement>().PauseMovement();
        }
        foreach (GameObject obj in catMews)
        {
            if (obj != null)
                obj.GetComponent<CatMeowing>().PauseSounds();
        }
        
        if (paused)
            kettle.GetComponent<AudioSource>().Pause();
        else
            kettle.GetComponent<AudioSource>().UnPause();
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

        //controller.GetComponent<FirstPersonController>().lockCursor = !controller.GetComponent<FirstPersonController>().lockCursor;
        //controller.GetComponent<FirstPersonController>().playerCanMove = !controller.GetComponent<FirstPersonController>().playerCanMove;
        //controller.GetComponent<FirstPersonController>().cameraCanMove = !controller.GetComponent<FirstPersonController>().cameraCanMove;
    }
}
