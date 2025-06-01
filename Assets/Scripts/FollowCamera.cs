using UnityEngine;

public class FollowCamera: MonoBehaviour
{
    public Transform head;
    public GameObject scoreboard;

    private void Start()
    {
        
    }

    private void Update()
    {
        scoreboard.transform.LookAt(new Vector3(head.position.x, scoreboard.transform.position.y, head.position.z));
        scoreboard.transform.forward *= -1;
    }
    
}
