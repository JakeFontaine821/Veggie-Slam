using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int ENEMYID;
    //flipplayer image
    bool facingRight = false;
    //general stuff
    public GameObject player;
    public float maxHealth;
    public float health;
    public int dmgDist;
    //bounce away from player when ground slammed
    int dirFromPlayer;
    public float bounceDist;
    public float slamPower;
    //movement back and forth
    public int moveDir = 1;
    public float movespeed;
    public float MaxSpeed;
    public float MinSpeed;
    public float rampUpSpeed;
    //Charge Enemy
    public bool charging = true;
    public float chargeDist = 2;
    public LayerMask stuff;
    //Animator
    Animator anim;

    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //enemy patrol movement
        transform.Translate(new Vector3(movespeed, 0, 0) * moveDir * Time.deltaTime);

        //change movespeed if charging
        if(charging == true && movespeed <= MaxSpeed)
        {
            movespeed += rampUpSpeed;
        }
        else if(charging == false && movespeed >= MinSpeed)
        {
            movespeed -= rampUpSpeed;
        }

        //check direction from player for bounce
        if (player.transform.position.x > gameObject.transform.position.x)
        { dirFromPlayer = -1; }
        else if (player.transform.position.x < gameObject.transform.position.x)
        { dirFromPlayer = 1; }

        //PLayer ground slam enemy
        if (Vector2.Distance(player.transform.position, gameObject.transform.position) <= dmgDist)
        {
            slamPower = player.GetComponent<PlayerMovement>().slamCounter;

            if (player.GetComponent<PlayerMovement>().hitGround == true)
            {
                //bounce enemy away
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bounceDist * dirFromPlayer, bounceDist) *
                    slamPower, ForceMode2D.Impulse);
            }
        }

        //Charging at player
        if (Physics2D.Raycast(transform.position, new Vector2(moveDir, 0), chargeDist, stuff))
        {
            if(charging == false)
            {
                charging = true;
                anim.SetBool("IsCharging", true);
            }            
        }
        else
        {
            if (charging == true)
            {
                charging = false;
                anim.SetBool("IsCharging", false);
            }
        }

        FlipPlayer(moveDir);
    }

    private void FlipPlayer(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 playerXScale = transform.localScale;
            playerXScale.x *= -1;
            transform.localScale = playerXScale;
        }
    }
}
