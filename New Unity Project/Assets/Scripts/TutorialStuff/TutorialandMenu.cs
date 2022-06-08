using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialandMenu : MonoBehaviour
{
    GameObject player;
    int dmgDist = 3;
    int dirFromPlayer;
    public float bounceDist;

    //slam level dummy camera movement stuff
    public bool slamLevel = false;
    public GameObject cameraController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.x > transform.position.x)
        {
            dirFromPlayer = -1;
        }
        else
        {
            dirFromPlayer = 1;
        }

        if (player.GetComponent<PlayerMovement>().hitGround == true)
        {
            if (player.GetComponent<PlayerMovement>().slamCounter <= .7f)
            {
                player.GetComponent<PlayerMovement>().slamCounter = .7f;
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

                if(slamLevel)
                {
                    cameraController.GetComponent<CameraFollowsThis>().sequence = 2;
                }
            }
        }
    }
}
