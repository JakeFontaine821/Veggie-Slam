using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEAN : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().stopMovement = 1.5f;
        }
    } 
}
