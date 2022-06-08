using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    GameObject player;
    public float moveSpeed;
    public int moveDirX;
    public int moveDirY;
    float changeDir = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(moveDirX, 0, 0) * moveSpeed * Time.fixedDeltaTime);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0) * moveSpeed;
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirX, 0) * moveSpeed;

        if(changeDir > 0)
        {
            changeDir -= Time.fixedDeltaTime;
        }
    }

    public void ChangeDirection()
    {
        if (changeDir <= 0)
        {            
            moveDirX *= -1;                  
            
            changeDir = 1;
        }        
    }
}
