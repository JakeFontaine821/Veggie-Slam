using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAI : MonoBehaviour
{
    GameObject player;
    public GameObject enemy;
    public float PlayerbounceDist;
    public float EnemybounceDist;
    public Sprite stand;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * EnemybounceDist, ForceMode2D.Impulse);
            player.GetComponent<SpriteRenderer>().sprite = stand;
            //player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }

        if (col.CompareTag("enemy"))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * PlayerbounceDist, ForceMode2D.Impulse);
            //enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.transform.Translate(new Vector3(-1, 0, 0) * Time.fixedDeltaTime);
        }

        if (col.CompareTag("enemy"))
        {
            enemy.transform.Translate(new Vector3(-1.5f, 0, 0) * Time.fixedDeltaTime);
        }
    }
}
