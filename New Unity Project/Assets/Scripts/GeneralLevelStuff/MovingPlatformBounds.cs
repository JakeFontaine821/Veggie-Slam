using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("MovingPlatform"))
        {
            col.GetComponent<MovingPlatform>().ChangeDirection();
        }
    }
}
