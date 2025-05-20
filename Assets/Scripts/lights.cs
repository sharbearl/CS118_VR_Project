using System.Collections.Generic;
using UnityEngine;

public class lights : MonoBehaviour, Interactable
{
    private List<GameObject> light = new List<GameObject>();
    private bool lightsOn = true;
    public AudioSource lightSwitchOn;
    public AudioSource lightSwitchOff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("cat room light"))
        {
            light.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        lightsOn = !lightsOn;
        PlaySound();
        Debug.Log("turning lights " + (lightsOn ? "on" : "off"));

        foreach (GameObject obj in light)
        {
            obj.SetActive(lightsOn);
        }
    }

    private void PlaySound()
    {
        if (lightsOn)
        {
            lightSwitchOn.Play();
        }
        else
        {
            lightSwitchOff.Play();
        }
    }
}
