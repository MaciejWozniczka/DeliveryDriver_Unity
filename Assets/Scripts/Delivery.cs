using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch! "+ other.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package"){
            Debug.Log("Package picked up");
        }
        
        if (other.tag == "Destination"){
            Debug.Log("Package delivered");
        }
    }
}