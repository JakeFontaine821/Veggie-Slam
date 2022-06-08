using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    //public LayerMask ground;
    [Header("General")]
    public GameObject player;
    public UnityEvent shockLess;
    public UnityEvent shockMore;
    public GameObject slamObject;
    Animator SmallSlam;
    //audio
    public AudioSource Sounds;
    public AudioClip BodySlam;

    void Start()
    {
        player = GameObject.Find("Player");
        SmallSlam = slamObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().canJump = true;

            if (player.GetComponent<PlayerMovement>().groundSlam == true)
            {
                //no longer slamming
                player.GetComponent<PlayerMovement>().groundSlam = false;
                //the split second the player hits the ground this way i can do all 
                //rigid body forces while hitground is true
                player.GetComponent<PlayerMovement>().hitGround = true;
                //turn off animation
                player.GetComponent<Animator>().SetBool("BodySlam", false);
                //play sound
                Sounds.PlayOneShot(BodySlam);

                if (player.GetComponent<PlayerMovement>().slamCounter <= .7f)
                {
                    player.GetComponent<PlayerMovement>().slamCounter = .7f;
                    shockLess.Invoke();
                    SmallSlam.SetTrigger("SmallSlam");
                }
                else
                {
                    shockMore.Invoke();
                    SmallSlam.SetTrigger("BigSlam");
                }            
            }                       
        }

        if(other.CompareTag("Artichoke"))
        {
            other.GetComponent<ArtichokeBehavior>().canJump = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().canJump = true;
            player.GetComponent<PlayerMovement>().hitGround = false;

            player.GetComponent<PlayerMovement>().slamCounter = 0;            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {     
            player.GetComponent<PlayerMovement>().canJump = false;            
        }
    }
}
