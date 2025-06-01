using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;
using UnityEngine.InputSystem;


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
    public GameObject movement;
    public InputActionReference pauseButton;
    public Transform head;
    public float menuDistance = 2;

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

        pauseButton.action.Enable();

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GoToMenu();
        }

        if (pauseButton.action.IsPressed()) {
            TogglePause();
            Debug.Log("Pause pressed");
        }

        //Ray r = new Ray(Source.position, Source.forward);
        //if (Physics.Raycast(r, out RaycastHit hitInfo, Range, mask))
        //{
        //    if (hitInfo.collider.gameObject.TryGetComponent(out Interactable obj))
        //    {
        //        interactText.SetActive(true);
        //        if (Input.GetKeyDown(KeyCode.E)) 
        //        { 
        //            Debug.Log("E key pressed");
        //            obj.Interact();
        //        }
        //    }
        //    else
        //    {
        //        interactText.SetActive(false);
        //    }
        //}
        //else
        //{
        //    interactText.SetActive(false);
        //}

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
        ShowMenu();
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

    private void ShowMenu()
    {
        pauseScreen.SetActive(paused);

        pauseScreen.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * menuDistance;
        pauseScreen.transform.LookAt(new Vector3(head.position.x, pauseScreen.transform.position.y, head.position.z));
        pauseScreen.transform.forward *= -1;
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

        movement.SetActive(!paused);
    }
}
