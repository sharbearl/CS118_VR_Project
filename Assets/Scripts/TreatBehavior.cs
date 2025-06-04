using UnityEngine;

public class TreatBehavior : MonoBehaviour
{
    public GameObject score;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cat") || collision.gameObject.CompareTag("MeowingCat") || collision.gameObject.CompareTag("MovingCat") )
        {
            print("cat");
            collision.gameObject.GetComponent<CatFeed>().catCollision();
            score.GetComponent<ScoreCounter>().UpdateScore();

            Destroy(gameObject); // Destroy the treat after hitting
        }
    }
}
