using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public WindowsPointer pointer;
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
    [SerializeField] GameObject package9;
    [SerializeField] GameObject package10;
    [SerializeField] GameObject destination1;
    [SerializeField] GameObject destination2;
    [SerializeField] GameObject destination3;
    [SerializeField] GameObject destination4;
    [SerializeField] GameObject destination5;
    [SerializeField] GameObject destination6;
    [SerializeField] GameObject destination7;
    [SerializeField] GameObject destination8;
    [SerializeField] GameObject destination9;
    [SerializeField] GameObject destination10;

    void Start()
    {
        DeactivateAll();
        package1.SetActive(true);
    }

    private void DeactivateAll()
    {
        package1.SetActive(false);
        package2.SetActive(false);
        package3.SetActive(false);
        package4.SetActive(false);
        package5.SetActive(false);
        package6.SetActive(false);
        package7.SetActive(false);
        package8.SetActive(false);
        package9.SetActive(false);
        package10.SetActive(false);

        destination1.SetActive(false);
        destination2.SetActive(false);
        destination3.SetActive(false);
        destination4.SetActive(false);
        destination5.SetActive(false);
        destination6.SetActive(false);
        destination7.SetActive(false);
        destination8.SetActive(false);
        destination9.SetActive(false);
        destination10.SetActive(false);
    }

    private void Update()
    {
        if (textIsDisplayed && hasPackage)
        {
            textUI.text = "Przesyłka zebrana!";
            textUI.enabled = true;

            if (readyForNextRound)
            {
                ChangeRound(hasPackage);
                readyForNextRound = false;
            }

            StartCoroutine(HideTextAfterDelay());
        }
        else if (textIsDisplayed && !hasPackage)
        {
            textUI.text = "Przesyłka dostarczona!";
            textUI.enabled = true;
            
            if (readyForNextRound)
            {
                ChangeRound(hasPackage);
                readyForNextRound = false;
            }

            StartCoroutine(HideTextAfterDelay());
        }
    }

    private void ChangeRound(bool hasPackage)
    {
        var random = new System.Random();
        currentRound = random.Next(0, 9) * 2;
        if (hasPackage) currentRound++;

        DeactivateAll();

        switch (currentRound)
        {
            case 0:
            package1.SetActive(true);
            pointer.targetPosition = package1.transform.position;
            break;
            case 1:
            destination1.SetActive(true);
            pointer.targetPosition = destination1.transform.position;
            break;
            case 2:
            package2.SetActive(true);
            pointer.targetPosition = package2.transform.position;
            break;
            case 3:
            destination2.SetActive(true);
            pointer.targetPosition = destination2.transform.position;
            break;
            case 4:
            package3.SetActive(true);
            pointer.targetPosition = package3.transform.position;
            break;
            case 5:
            destination3.SetActive(true);
            pointer.targetPosition = destination3.transform.position;
            break;
            case 6:
            package4.SetActive(true);
            pointer.targetPosition = package4.transform.position;
            break;
            case 7:
            destination4.SetActive(true);
            pointer.targetPosition = destination4.transform.position;
            break;
            case 8:
            package5.SetActive(true);
            pointer.targetPosition = package5.transform.position;
            break;
            case 9:
            destination5.SetActive(true);
            pointer.targetPosition = destination5.transform.position;
            break;
            case 10:
            package6.SetActive(true);
            pointer.targetPosition = package6.transform.position;
            break;
            case 11:
            destination6.SetActive(true);
            pointer.targetPosition = destination6.transform.position;
            break;
            case 12:
            package7.SetActive(true);
            pointer.targetPosition = package7.transform.position;
            break;
            case 13:
            destination7.SetActive(true);
            pointer.targetPosition = destination7.transform.position;
            break;
            case 14:
            package8.SetActive(true);
            pointer.targetPosition = package8.transform.position;
            break;
            case 15:
            destination8.SetActive(true);
            pointer.targetPosition = destination8.transform.position;
            break;
            case 16:
            package9.SetActive(true);
            pointer.targetPosition = package9.transform.position;
            break;
            case 17:
            destination9.SetActive(true);
            pointer.targetPosition = destination9.transform.position;
            break;
            case 18:
            package10.SetActive(true);
            pointer.targetPosition = package10.transform.position;
            break;
            case 19:
            destination10.SetActive(true);
            pointer.targetPosition = destination10.transform.position;
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && other.enabled && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            textIsDisplayed = true;
            readyForNextRound = true;
        }
        
        if (other.tag == "Destination" && other.enabled && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            textIsDisplayed = true;
            readyForNextRound = true;
        }
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        textUI.enabled = false;
        textIsDisplayed = false;
    }
}