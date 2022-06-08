using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounds : MonoBehaviour
{
    public GameObject enemy;
    public char LorR;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemy"))
        {
            if (col.GetComponent<EnemyScript>().ENEMYID == enemy.GetComponent<EnemyScript>().ENEMYID)
            {
                if (LorR == 'R' && col.GetComponent<EnemyScript>().moveDir == 1)
                {
                    enemy.GetComponent<EnemyScript>().moveDir *= -1;
                }
                else if (LorR == 'L' && col.GetComponent<EnemyScript>().moveDir == -1)
                {
                    enemy.GetComponent<EnemyScript>().moveDir *= -1;
                }
            }
        }        
    }
}
