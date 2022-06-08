using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HolStuff : MonoBehaviour
{
    GameObject player;
    public GameObject resetLoc;
    public bool win = false;
    public float winCountDown;
    public GameObject success;
    public GameObject removeWall;
    public GameObject closeGap;
    public GameObject jumpB;
    public GameObject jumpA;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            player.transform.position = resetLoc.transform.position;
        }

        if(col.CompareTag("enemy"))
        {
            //success.SetActive(true);
            //winCountDown = 5;
            Destroy(col);
            removeWall.SetActive(false);
            closeGap.SetActive(true);
            jumpB.SetActive(false);
            jumpA.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if(winCountDown > 0 && win == false)
        {
            winCountDown -= Time.fixedDeltaTime;

            if(winCountDown < 1)
            {
                win = true;
            }
        }

        if(win == true)
        {
            SceneManager.LoadScene(2);
        }
    }
}
