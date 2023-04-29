using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GroundController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Transform playerTransform = other.GetComponent<Transform>();
            
            playerTransform.position = new Vector3(playerTransform.position.x, transform.position.y + 1.0f, playerTransform.position.z);
        }
    }
}
