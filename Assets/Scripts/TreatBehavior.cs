using UnityEngine;

public class TreatBehavior : MonoBehaviour
{
    public GameObject heartBubblePrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            Instantiate(heartBubblePrefab, collision.contacts[0].point, Quaternion.identity);
        }

        Destroy(gameObject); // Destroy the treat after hitting
    }
}
