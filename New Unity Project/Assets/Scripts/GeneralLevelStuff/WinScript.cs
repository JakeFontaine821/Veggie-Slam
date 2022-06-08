using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject successImage;
    bool win = false;
    public float winTimer = 0;
    public int NextScene;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(winTimer > 0 && win == true)
        {
            winTimer -= Time.fixedDeltaTime;
        }

        if(winTimer <= 0 && win == true)
        {
            SceneManager.LoadScene(NextScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && win == false)
        {
            successImage.SetActive(true);
            winTimer = 3;
            win = true;
        }
    }
}
