using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStuff : MonoBehaviour
{
    GameObject player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        if(player.GetComponent<PlayerMovement>().dashDir.x > 0 && player.GetComponent<PlayerMovement>().dashDir.y == 0)
        {
            anim.SetInteger("Dir", 1);
        }
        else if(player.GetComponent<PlayerMovement>().dashDir.x > 0 && player.GetComponent<PlayerMovement>().dashDir.y > 0)
        {
            anim.SetInteger("Dir", 2);
        }
        else if (player.GetComponent<PlayerMovement>().dashDir.x == 0 && player.GetComponent<PlayerMovement>().dashDir.y > 0)
        {
            anim.SetInteger("Dir", 3);
        }
        else if (player.GetComponent<PlayerMovement>().dashDir.x < 0 && player.GetComponent<PlayerMovement>().dashDir.y > 0)
        {
            anim.SetInteger("Dir", 4);
        }
        else if (player.GetComponent<PlayerMovement>().dashDir.x < 0 && player.GetComponent<PlayerMovement>().dashDir.y == 0)
        {
            anim.SetInteger("Dir", 5);
        }
        else if (player.GetComponent<PlayerMovement>().dashDir.x < 0 && player.GetComponent<PlayerMovement>().dashDir.y < 0)
        {
            anim.SetInteger("Dir", 6);
        }
        else if (player.GetComponent<PlayerMovement>().dashDir.x == 0 && player.GetComponent<PlayerMovement>().dashDir.y < 0)
        {
            anim.SetInteger("Dir", 7);
        }
        else if (player.GetComponent<PlayerMovement>().dashDir.x > 0 && player.GetComponent<PlayerMovement>().dashDir.y < 0)
        {
            anim.SetInteger("Dir", 8);
        }
        else
        {
            anim.SetInteger("Dir", 0);
        }
    }
}
