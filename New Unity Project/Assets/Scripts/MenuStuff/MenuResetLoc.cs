using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResetLoc : MonoBehaviour
{
    GameObject player;
    public GameObject enemy;
    public GameObject resetLoc;
    public float launchX;
    public float launchY;
    public Sprite swan;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY);
            player.GetComponent<SpriteRenderer>().sprite = swan;
        }

        if(col.CompareTag("enemy"))
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY);
        }
    }
}
