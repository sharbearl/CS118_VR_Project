using UnityEngine;

public class CatFeed : MonoBehaviour
{
    public ParticleSystem hearts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hearts.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void catCollision()
    {
        hearts.Play();
    }
}
