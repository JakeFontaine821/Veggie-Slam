using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public GameObject enemy;
    public float KnockBackX;
    public float KnockBackY;
    float waitToHitAgain = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && enemy.GetComponent<EnemyScript>().charging == true && waitToHitAgain <= 0)
        {
            //knock away player
            col.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(KnockBackX * enemy.GetComponent<EnemyScript>().moveDir, KnockBackY), ForceMode2D.Impulse);

            //knock away enemy
            enemy.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(KnockBackX * -enemy.GetComponent<EnemyScript>().moveDir, KnockBackY), ForceMode2D.Impulse);

            waitToHitAgain = .5f;
        }
    }

    private void FixedUpdate()
    {
        if(waitToHitAgain > 0)
        {
            waitToHitAgain -= Time.fixedDeltaTime;
        }
    }
}
