using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    //MOVEMENT
    [Header("Movement")]
    float h;
    public Vector2 dashDir;
    public float speed;
    bool facingRight = true;
    //JUMP
    [Header("Jump")]
    public bool canJump;
    public float jumpHeight;
    //DASH
    [Header("Dash")]
    public bool dash;
    public float dashSpeed;
    public float dashCounter = 0;
    public Image DashCD;
    //GROUND SLAM
    [Header("Ground Slam")]
    public bool groundSlam;
    public bool hitGround;
    public float slamCounter;
    //ANIMATE PLAYER
    Animator anim;
    //STOPMOVEMENT HIT BY LIMABEAN
    [Header("Stop Movement from limas")]
    public float stopMovement = 0;
    public GameObject StunnedUI;
    //REVERSE CONTROLS HIT BY ONION
    [Header("Reverse Controlls")]
    public float reverseControls;
    public GameObject InverseControlUI;
    //AUDIO
    [Header("Audio Files")]
    public AudioSource Sounds;
    public AudioClip JumpSound;
    public AudioClip StartSlamSound;
    //CAN MOVE IN LAUNCH LEVEL
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove) 
        {
            InputManager();
        }

        if(stopMovement <= 0)
        {
            StunnedUI.SetActive(false);

            if (reverseControls <= 0)
            {
                //turn on ui
                InverseControlUI.SetActive(false);
                //move player
                transform.Translate(new Vector3(h, 0, 0) * speed * Time.fixedDeltaTime);
            }
            else
            {
                InverseControlUI.SetActive(true);
                transform.Translate(new Vector3(h, 0, 0) * speed * -1 * Time.fixedDeltaTime);
            }            

            if (dash && dashCounter >= 2)
            {
                if (dashDir.x != 0 || dashDir.y != 0)
                {
                    Sounds.PlayOneShot(StartSlamSound);
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dashSpeed * dashDir.x, dashSpeed * dashDir.y), ForceMode2D.Impulse);
                    dashCounter = 0;

                    if (canJump == false)
                    {
                        groundSlam = true;
                        anim.SetBool("BodySlam", true);
                    }
                }
            }
        }

        if (dashCounter <= 2)
        {
            dashCounter += Time.deltaTime;
            dash = false;
            DashCD.fillAmount = dashCounter / 2;
        }

        if(groundSlam)
        {
            slamCounter += Time.fixedDeltaTime;
        }

        if (stopMovement > 0)
        {
            StunnedUI.SetActive(true);
            stopMovement -= Time.fixedDeltaTime;
        }

        if (reverseControls > 0)
        {
            reverseControls -= Time.fixedDeltaTime;
        }
    }

    public void InputManager()
    {
        /***********/
        /* RUNNING */
        /***********/
        h = Input.GetAxisRaw("Horizontal");
        FlipPlayer(h);
        if (h != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        /***********/
        /* JUMPING */
        /***********/
        if (Input.GetAxisRaw("Jump") == 1 && canJump == true)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
            Sounds.PlayOneShot(JumpSound);
        }

        /*****************************/
        /* DASH DIRECTION HORIZONTAL */
        /*****************************/
        dashDir.x = Input.GetAxisRaw("XDashDir");

        /***************************/
        /* DASH DIRECTION VERTICAL */
        /***************************/
        dashDir.y = Input.GetAxisRaw("YDashDir");

        /****************/
        /* TRIGGER DASH */
        /****************/
        if(Input.GetAxisRaw("Dash") == 1)
        {
            dash = true;
        }
    }

    //public void MovePlayer(InputAction.CallbackContext context)
    //{
    //    h = context.ReadValue<float>();

    //    FlipPlayer(h);
    //    if (h != 0)
    //    {
    //        anim.SetBool("Running", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("Running", false);
    //    }
    //}

    //public void PlayerJump(InputAction.CallbackContext context)
    //{
    //    if(canJump == true)
    //    {
    //        canJump = false;
    //        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    //        anim.SetTrigger("Jump");
    //        Sounds.PlayOneShot(JumpSound);
    //    }
    //}

    //public void DashDirectionX(InputAction.CallbackContext context)
    //{
    //    dashDir.x = context.ReadValue<float>();


    //}

    //public void DashDirectionY(InputAction.CallbackContext context)
    //{
    //    dashDir.y = context.ReadValue<float>();
    //}

    //public void Dash(InputAction.CallbackContext context)
    //{
    //    dash = true;
    //}

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
