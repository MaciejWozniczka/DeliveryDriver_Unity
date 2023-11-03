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
        if (other.tag == "Package")
        {
            Debug.Log("Package picked up");
            hasPackage = true;
        }
        
        if (other.tag == "Destination" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
        }
    }
}