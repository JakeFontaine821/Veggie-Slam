using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetArtLoc : MonoBehaviour
{
    public GameObject artichoke;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = artichoke.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("enemy"))
        {
            artichoke.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            artichoke.transform.position = startpos;
            //artichoke.SetActive(false);
            //artichoke.SetActive(true);
        }
    }
}
