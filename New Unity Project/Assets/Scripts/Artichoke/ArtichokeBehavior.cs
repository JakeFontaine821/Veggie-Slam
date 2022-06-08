using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtichokeBehavior : MonoBehaviour
{
    //flipplayer image
    bool facingRight = false;
    //basic movement, artichoke moves ENTIRLY through jumps
    public bool canJump;
    public float jumpHeight;
    public float jumpDist;
    public int jumpDir;
    int playerKnockDir;
    public float nextJumpTimer;
    public float jumpCD;
    //tracking and targeting player
    public GameObject player;
    public float TargetPlayerRange;
    //player hits
    public float health;
    public float dmgDist;
    int dirFromPlayer;
    public float bounceDist;
    //hit player
    public float KnockBackX;
    public float KnockBackY;
    float waitToHitAgain = 0;
    //animator
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
        if (Vector2.Distance(transform.position, player.transform.position) <= TargetPlayerRange)
        {
            if (canJump && nextJumpTimer <= 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                canJump = false;
                nextJumpTimer = jumpCD;                

                anim.SetTrigger("Jump");
            }
            
            if(canJump == false)
            {
                transform.Translate(new Vector3(jumpDist, 0, 0) * jumpDir * Time.fixedDeltaTime);
            }

            if (gameObject.transform.position.x > player.transform.position.x)
            {
                if (canJump) { jumpDir = -1; }
                playerKnockDir = -1;
            }
            else
            {
                if (canJump) { jumpDir = 1; }
                playerKnockDir = 1;
            }
        }

        if(nextJumpTimer > 0)
        {
            nextJumpTimer -= Time.fixedDeltaTime;
        }

        if (player.GetComponent<PlayerMovement>().hitGround == true && canJump == true)
        {
            if (player.GetComponent<PlayerMovement>().slamCounter <= 1)
            {
                player.GetComponent<PlayerMovement>().slamCounter = 1f;
            }
            if (Vector2.Distance(player.transform.position, gameObject.transform.position) <= dmgDist)
            {
                //check direction from player for bounce
                if (player.transform.position.x > gameObject.transform.position.x)
                { dirFromPlayer = -1; }
                else if (player.transform.position.x < gameObject.transform.position.x)
                { dirFromPlayer = 1; }
                //bounce enemy away
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bounceDist * dirFromPlayer, bounceDist) *
                    player.GetComponent<PlayerMovement>().slamCounter, ForceMode2D.Impulse);
            }            
        }

        //allow for hit again
        if (waitToHitAgain > 0)
        {
            waitToHitAgain -= Time.fixedDeltaTime;
        }

        FlipPlayer(jumpDir);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && waitToHitAgain <= 0)
        {
            //knock back player
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(KnockBackX * playerKnockDir, KnockBackY) * 2, ForceMode2D.Impulse);

            //knock back artichoke
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(KnockBackX * -jumpDir, KnockBackY), ForceMode2D.Impulse);

            waitToHitAgain = .5f;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && waitToHitAgain <= 0)
        {
            //knock back player
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(KnockBackX * playerKnockDir, KnockBackY) * 2, ForceMode2D.Impulse);

            //knock back artichoke
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(KnockBackX * -jumpDir, KnockBackY), ForceMode2D.Impulse);

            waitToHitAgain = .5f;
        }
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
