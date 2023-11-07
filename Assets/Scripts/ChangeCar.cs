using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCar : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Car")
        {
            Debug.Log("Car changed!");
            spriteRenderer.sprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
            
            Destroy(other.gameObject);
        }
    }
}
