using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


	public class Door : MonoBehaviour {
		public bool open;
		public float smooth = 1.0f;
		float DoorOpenAngle = -90.0f;
		float DoorCloseAngle = 0.0f;
		public AudioSource asource;
		public AudioClip openDoor,closeDoor;

		private Animator animator;
		// Use this for initialization
		void Start () {
			asource = GetComponent<AudioSource> ();
			animator = GetComponentInChildren<Animator> ();
		}
	
		// Update is called once per frame
		void Update () {
		}

		public void OpenDoor(){
			open =!open;
			asource.clip = open?openDoor:closeDoor;
			asource.Play ();
            if (open)
            {
                animator.SetInteger("state", 1);
            }
            else
            {
                animator.SetInteger("state", 0);
            }
        }
	}
}