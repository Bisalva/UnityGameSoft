using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{

    private Prota playerController;
    public bool HealthStatusCheck;
    void Start()
    {
        playerController = GameObject.Find("Prot").GetComponent<Prota>();

    }

    void Update()
    {
        HealthStatusCheck = playerController.CanLife;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && HealthStatusCheck)
        {
            Destroy(gameObject); 
        }
    }

}
