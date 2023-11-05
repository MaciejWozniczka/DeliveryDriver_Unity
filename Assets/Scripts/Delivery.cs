using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    bool readyForNextRound = false;
    private bool textIsDisplayed = false;
    public TextMeshProUGUI textUI;
    public int currentRound = 1;
    [SerializeField] GameObject package1;
    [SerializeField] GameObject package2;
    [SerializeField] GameObject package3;
    [SerializeField] GameObject package4;
    [SerializeField] GameObject package5;
    [SerializeField] GameObject package6;
    [SerializeField] GameObject package7;
    [SerializeField] GameObject package8;
    [SerializeField] GameObject destination1;
    [SerializeField] GameObject destination2;
    [SerializeField] GameObject destination3;
    [SerializeField] GameObject destination4;
    [SerializeField] GameObject destination5;
    [SerializeField] GameObject destination6;
    [SerializeField] GameObject destination7;
    [SerializeField] GameObject destination8;

    void Start()
    {
        package1.SetActive(true);
        package2.SetActive(false);
        package3.SetActive(false);
        package4.SetActive(false);
        package5.SetActive(false);
        package6.SetActive(false);
        package7.SetActive(false);
        package8.SetActive(false);

        destination1.SetActive(true);
        destination2.SetActive(false);
        destination3.SetActive(false);
        destination4.SetActive(false);
        destination5.SetActive(false);
        destination6.SetActive(false);
        destination7.SetActive(false);
        destination8.SetActive(false);
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
            
            if (readyForNextRound)
            {
                ChangeRound();
                readyForNextRound = false;
            }

            StartCoroutine(HideTextAfterDelay());
        }
        else if (currentRound == 8)
        {
            textUI.text = "Przesyłka dostarczona!";
            textUI.enabled = true;

            StartCoroutine(HideTextAfterDelay());
        }
    }

    private void ChangeRound()
    {
        switch (currentRound)
        {
            case 1:
            package2.SetActive(true);
            destination2.SetActive(true);
            break;
            case 2:
            package3.SetActive(true);
            destination3.SetActive(true);
            break;
            case 3:
            package4.SetActive(true);
            destination4.SetActive(true);
            break;
            case 4:
            package5.SetActive(true);
            destination5.SetActive(true);
            break;
            case 5:
            package6.SetActive(true);
            destination6.SetActive(true);
            break;
            case 6:
            package7.SetActive(true);
            destination7.SetActive(true);
            break;
            case 7:
            package8.SetActive(true);
            destination8.SetActive(true);
            break;
            case 8:
            textIsDisplayed = true;
            break;
        }

        currentRound++;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && other.enabled && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            textIsDisplayed = true;
            Destroy(other.gameObject);
        }
        
        if (other.tag == "Destination" && other.enabled && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            textIsDisplayed = true;
            readyForNextRound = true;
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