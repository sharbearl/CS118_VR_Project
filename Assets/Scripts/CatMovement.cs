using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public int length;
    public int waitTime;

    private Animator animator;
    private bool idle = true;
    private int sinceStart = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger("state", 0);
        transform.Rotate(0, 180f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (idle)
        {
            if (sinceStart > waitTime)
            {
                idle = false;
                sinceStart = 0;
                animator.SetInteger("state", 1);
                transform.Rotate(0, 180f, 0);
            }
        }
        else
        {
            if (sinceStart > length)
            {
                idle = true;
                sinceStart = 0;
                animator.SetInteger("state", 0);
            }
            else
                transform.Translate(Vector3.forward / 2 * Time.deltaTime);
        }
        sinceStart += 1;
    }
}
