using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    private bool textIsDisplayed = false;
    public TextMeshProUGUI textUI;

    void Start()
    {
    }

    private void Update()
    {
        if (textIsDisplayed && hasPackage)
        {
            textUI.text = "Przesyłka zebrana!";
            textUI.enabled = true;
            StartCoroutine(HideTextAfterDelay());
        }
        else if (textIsDisplayed && !hasPackage)
        {
            textUI.text = "Przesyłka dostarczona!";
            textUI.enabled = true;
            StartCoroutine(HideTextAfterDelay());
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch! "+ other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            textIsDisplayed = true;
            Destroy(other.gameObject);
        }
        
        if (other.tag == "Destination" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            textIsDisplayed = true;
        }
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        textUI.enabled = false;
        textIsDisplayed = false;
    }
}