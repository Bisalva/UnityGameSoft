using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prota : MonoBehaviour
{

    public float JumpForce;
    public float BoingForce = 10f;
    public float BounceForce = 100;
    public float Speed;
    public float Lifes = 100;
    public float LifesMax;
    public bool CanLife;


    private Animator Animator;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    private bool SuperTouch;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        LifesMax = Lifes;

    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 1))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();

        }

        if (Lifes < LifesMax)
        {
            CanLife = true;
        }


    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    public void Damage()
    {
        Lifes -= 25;

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") && CanLife)
        {
            Lifes += 25;
            if (Lifes >= LifesMax)
            {
                Lifes = LifesMax;
                CanLife = false;
            }
        }
        else if (collision.CompareTag("SuperItem") && CanLife)
        {

            Lifes += 50;
            if (Lifes >= LifesMax)
            {
                Lifes = LifesMax;
                CanLife = false;
            }
        }



    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

}
