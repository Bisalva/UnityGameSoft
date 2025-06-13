using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{

    private Enemy enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("SEnemy"))
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.DamageInEnemy(1);
        }
    }

}
