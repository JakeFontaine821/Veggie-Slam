using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionBehavior : MonoBehaviour
{
    //attack the player at this range
    public GameObject player;
    bool facingRight = false;
    public int attackRange;
    int dirfromplayer;
    //Grow the trigger radius when player gets within range
    bool SPRAY = false;
    int count = 0;
    public float cloudGrowth;
    public Vector2 CloudMinMax;
    public float CloudRadius = 1;
    public CircleCollider2D gasCloud;
    //spray cooldown
    float CD;
    public float cooldown;
    //animate the onion
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= attackRange && CD <= 0)
        {
            //start attack
            SPRAY = true;
            //start animation
            anim.SetTrigger("Spray");
        }    
        
        if(SPRAY == true)
        {          
            //grow the collider
            CloudRadius += cloudGrowth;

            if (CloudRadius >= CloudMinMax.y)
            {
                //reset size
                CloudRadius = CloudMinMax.x;
                //stop
                SPRAY = false;              
            }

            gasCloud.radius = CloudRadius;

            //set cooldown
            CD = cooldown;
        }

        if (CD > 0)
        {
            CD -= Time.fixedDeltaTime;
        }

        if(player.transform.position.x >= transform.position.x)
        {
            dirfromplayer = 1;
        }
        else
        {
            dirfromplayer = -1;
        }

        FlipOnion(dirfromplayer);
    }

    private void FlipOnion(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 playerXScale = transform.localScale;
            playerXScale.x *= -1;
            transform.localScale = playerXScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && SPRAY == true)
        {
            player.GetComponent<PlayerMovement>().reverseControls = 1.5f;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && SPRAY == true)
        {
            player.GetComponent<PlayerMovement>().reverseControls = 1.5f;
        }
    }
}
