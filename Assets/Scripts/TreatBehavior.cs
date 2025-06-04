using UnityEngine;

public class TreatBehavior : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cat") || collision.gameObject.CompareTag("MeowingCat") || collision.gameObject.CompareTag("MovingCat") )
        {
            collision.gameObject.catCollision;
        }

        Destroy(gameObject); // Destroy the treat after hitting
    }
}
