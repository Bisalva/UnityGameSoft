using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{


    private Enemy enemy;
    private Vector2 initialPosition;
    private bool DoneTrayectory;
    public int distance;



    void Start()
    {
        initialPosition = transform.position;
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        int speedEnemy = enemy.speed;
        bool orientation = enemy.Horizontal;




        if (orientation)
        {
            if (DoneTrayectory)
            {
                transform.Translate(Vector2.right * speedEnemy * Time.deltaTime);

                if (transform.position.x >= initialPosition.x + distance)
                {
                    DoneTrayectory = false;
                }

            }
            else
            {
                transform.Translate(Vector2.left * speedEnemy * Time.deltaTime);

                if (transform.position.x <= initialPosition.x - distance)
                {
                    DoneTrayectory = true;
                }
            }
        }
        else
        {
            if (DoneTrayectory)
            {
                transform.Translate(Vector2.up * speedEnemy * Time.deltaTime);

                if (transform.position.y >= initialPosition.y + distance)
                {
                    DoneTrayectory = false;
                }

            }
            else
            {
                transform.Translate(Vector2.down * speedEnemy * Time.deltaTime);

                if (transform.position.y <= initialPosition.y - distance)
                {
                    DoneTrayectory = true;
                }
            }
        }



    }
}
