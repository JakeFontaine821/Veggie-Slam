using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLocTrigger : MonoBehaviour
{
    GameObject player;
    public GameObject resetLoc;
    public bool ReloadLevel;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            player.transform.position = resetLoc.transform.position;

            if(ReloadLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }            
        }
    }
}
