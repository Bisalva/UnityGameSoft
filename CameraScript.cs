using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Prota;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Prota.transform.position.x;
        position.y = Prota.transform.position.y;
        transform.position = position; 
 

    }
}
