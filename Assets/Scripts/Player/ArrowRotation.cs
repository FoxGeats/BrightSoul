using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{




    // Update is called once per frame
    void Update()
    {
        Vector3 direction =  Camera.main.WorldToScreenPoint(transform.position) -Input.mousePosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        /*Debug.Log(direction);*/
    }
}

