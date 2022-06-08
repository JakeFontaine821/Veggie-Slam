using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimaBehavior : MonoBehaviour
{
    //player object for tracking and aiming
    GameObject player;
    //attack stuff
    public int attackDist;
    public LayerMask stuff;
    public GameObject[] Leftbean;
    public Vector3 LeftStartPos;
    int currentLeftbean = 0;
    public GameObject[] Upbean;
    public Vector3 UpStartPos;
    int currentUpbean = 0;
    public GameObject[] Rightbean;
    public Vector3 RightStartPos;
    int currentRightbean = 0;
    //shooting stuff
    public int speed;
    public float Cooldown;
    float shootCD;
    //animate the legumes
    public GameObject Leftlegume;
    public GameObject Uplegume;
    public GameObject Rightlegume;

    // Start is called before the first frame update
    void Start()
    {        
        //grab player
        player = GameObject.Find("Player");

        //start them inactive
        foreach (GameObject l in Leftbean)
        {
            l.SetActive(false);
        }
        LeftStartPos = Leftbean[0].transform.position;

        foreach (GameObject u in Upbean)
        {
            u.SetActive(false);
        }
        UpStartPos = Upbean[0].transform.position;

        foreach (GameObject r in Rightbean)
        {
            r.SetActive(false);
        }
        RightStartPos = Rightbean[0].transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Raycast LEFT
        if (Physics2D.Raycast(transform.position, new Vector2(-1, 0), attackDist, stuff))
        {
            //shoot is off CD and ready
            if(shootCD <= 0)
            {
                //animate left legume
                Leftlegume.GetComponent<Animator>().SetTrigger("Shoot");
                //set active
                Leftbean[currentLeftbean].SetActive(true);
                //reset bean position
                //Leftbean[currentLeftbean].transform.position = transform.position;
                Leftbean[currentLeftbean].transform.position = LeftStartPos;
                //apply force
                Leftbean[currentLeftbean].GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0) * -1);
                //next bean
                currentLeftbean++;
                //set cooldown
                shootCD = Cooldown;
                //reset array counter
                if(currentLeftbean >= Leftbean.Length)
                {
                    currentLeftbean = 0;
                }
            }            
        }

        //Raycast UP
        if (Physics2D.Raycast(transform.position, new Vector2(0, 1), attackDist, stuff))
        {
            //shoot is off CD and ready
            if (shootCD <= 0)
            {
                //animate left legume
                Uplegume.GetComponent<Animator>().SetTrigger("Shoot");
                //set active
                Upbean[currentUpbean].SetActive(true);
                //reset bean position
                //Upbean[currentUpbean].transform.position = transform.position;
                Upbean[currentUpbean].transform.position = UpStartPos;
                //apply force
                Upbean[currentUpbean].GetComponent<Rigidbody2D>().AddForce(new Vector2( 0, speed) * 1);
                //next bean
                currentUpbean++;
                //set cooldown
                shootCD = Cooldown;
                //reset array counter
                if (currentUpbean >= Upbean.Length)
                {
                    currentUpbean = 0;
                }
            }
        }

        //Raycast RIGHT
        if (Physics2D.Raycast(transform.position, new Vector2(1, 0), attackDist, stuff))
        {
            //shoot is off CD and ready
            if (shootCD <= 0)
            {
                //animate left legume
                Rightlegume.GetComponent<Animator>().SetTrigger("Shoot");
                //set active
                Rightbean[currentRightbean].SetActive(true);
                //reset bean position
                //Rightbean[currentRightbean].transform.position = transform.position;
                Rightbean[currentRightbean].transform.position = RightStartPos;
                //apply force
                Rightbean[currentRightbean].GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
                //next bean
                currentRightbean++;
                //set cooldown
                shootCD = Cooldown;
                //reset array counter
                if (currentRightbean >= Rightbean.Length)
                {
                    currentRightbean = 0;
                }
            }
        }

        if (shootCD > 0)
        {
            shootCD -= Time.fixedDeltaTime;
        }
    }
}
