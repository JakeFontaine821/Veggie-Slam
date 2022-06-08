using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimaBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BEAN"))
        {
            col.gameObject.SetActive(false);
        }
    }
}
