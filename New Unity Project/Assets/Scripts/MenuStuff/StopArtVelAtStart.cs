using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopArtVelAtStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
