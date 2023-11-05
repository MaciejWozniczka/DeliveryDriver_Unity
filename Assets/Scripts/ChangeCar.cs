using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeCar : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private bool textIsDisplayed = false;
    public TextMeshProUGUI textUI;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (textIsDisplayed)
        {
            textUI.text = "Zmieniono samochód!";
            textUI.enabled = true;
            StartCoroutine(HideTextAfterDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Car")
        {
            Debug.Log("Car changed!");
            spriteRenderer.sprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
            
            textIsDisplayed = true;

            Destroy(other.gameObject);
        }
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        textUI.enabled = false;
        textIsDisplayed = false;
    }
}
