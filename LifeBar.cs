using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image fillBar;
    private Prota playerController;
    private float MaxLife;
    void Start()
    {
        playerController = GameObject.Find("Prot").GetComponent<Prota>();
        MaxLife = playerController.Lifes;
    }

    void Update()
    {
        fillBar.fillAmount = playerController.Lifes / MaxLife;
    }
}
