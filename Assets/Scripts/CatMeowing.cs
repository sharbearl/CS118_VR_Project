using System.Threading;
using UnityEngine;

public class CatMeowing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource catSound;
    private int timer = 0;
    private bool paused = false;

    void Start()
    {
        timer = Random.Range(100, 500);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            catSound.Play();
            timer = Random.Range(100, 1000);
        }

        if (!paused)
        {
            --timer;
        }
    }

    public void PauseSounds()
    {
        Debug.Log("Cat sound paused");
        paused = !paused;
        if (paused)
        {
            catSound.Pause();
        }
        else
        {
            catSound.UnPause();
        }
    }
}
