using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Animator Animator;

    public int speed;
    public bool Horizontal;

    public int Lifes;


    void Start()
    {

        Animator = GetComponent<Animator>();

        if (gameObject.tag == "Enemy")
        {
            Lifes = 1;
        }
        else if (gameObject.tag == "SEnemy")
        {
            Lifes = 3;
        }
    }

    void Update()
    {

    }

    public void DamageInEnemy(int DamageTaken)
    {
        Animator.SetTrigger("Damage");
        Lifes -= DamageTaken;


        if (Lifes <= 0)
        {
            Animator.SetTrigger("Death");
            StartCoroutine(DestroyAfterDeath());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        collision.gameObject.GetComponent<Prota>().Damage();

    }
    
    private IEnumerator DestroyAfterDeath()
    {
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
