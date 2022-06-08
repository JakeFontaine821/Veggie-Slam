using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsThis : MonoBehaviour
{
    GameObject player;
    public GameObject artichoke;
    public float waitTimer = 2;
    public int sequence = 0;
    public float panSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(waitTimer > 0)
        {
            waitTimer -= Time.fixedDeltaTime;
        }
        else
        {
            if(sequence == 0)
            {
                if(transform.position.x > player.transform.position.x)
                {
                    Debug.Log(transform.position.x);
                    transform.Translate(new Vector3(-panSpeed, 0, 0) * Time.fixedDeltaTime);
                }
                else
                {
                    player.GetComponent<PlayerMovement>().enabled = true;
                    player.GetComponent<PlayerMovement>().canMove = true;
                    sequence = 1;
                }
            }
            else if(sequence == 1)
            {
                transform.position = player.transform.position;
            }
            else
            {
                transform.position = artichoke.transform.position;

                if(artichoke.GetComponent<Rigidbody2D>().velocity.x > -1 &&
                   artichoke.GetComponent<Rigidbody2D>().velocity.x < 1 &&
                   artichoke.GetComponent<Rigidbody2D>().velocity.y < 1 &&
                   artichoke.GetComponent<Rigidbody2D>().velocity.y > -1)
                {
                    sequence = 1;
                }
            }
        }
    }
}
