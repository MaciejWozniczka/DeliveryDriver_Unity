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
        package1.SetActive(true);
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
                ChangeRound();
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
                ChangeRound();
                readyForNextRound = false;
            }

            StartCoroutine(HideTextAfterDelay());
        }
        else if (currentRound == 21)
        {
            textUI.text = "Wygrałeś! Gratulacje!";
            textUI.enabled = true;

            StartCoroutine(HideTextAfterDelay());
        }
    }

    private void ChangeRound()
    {
        switch (currentRound)
        {
            case 1:
            package1.SetActive(false);
            destination1.SetActive(true);
            pointer.targetPosition = new Vector3(45.7f, 59.9f, 0);
            break;
            case 2:
            destination1.SetActive(false);
            package2.SetActive(true);
            pointer.targetPosition = new Vector3(-34.8f, 33.5f, 0);
            break;
            case 3:
            package2.SetActive(false);
            destination2.SetActive(true);
            pointer.targetPosition = new Vector3(35.2f, 13.4f, 0);
            break;
            case 4:
            destination2.SetActive(false);
            package3.SetActive(true);
            pointer.targetPosition = new Vector3(-48.5f, 60.7f, 0);
            break;
            case 5:
            package3.SetActive(false);
            destination3.SetActive(true);
            pointer.targetPosition = new Vector3(-49f, 42.2f, 0);
            break;
            case 6:
            destination3.SetActive(false);
            package4.SetActive(true);
            pointer.targetPosition = new Vector3(24.9f, -60.9f , 0);
            break;
            case 7:
            package4.SetActive(false);
            destination4.SetActive(true);
            pointer.targetPosition = new Vector3(28.9f, 44.5f, 0);
            break;
            case 8:
            destination4.SetActive(false);
            package5.SetActive(true);
            pointer.targetPosition = new Vector3(36.2f, 6.7f, 0);
            break;
            case 9:
            package5.SetActive(false);
            destination5.SetActive(true);
            pointer.targetPosition = new Vector3(-34.7f, 31.6f, 0);
            break;
            case 10:
            destination5.SetActive(false);
            package6.SetActive(true);
            pointer.targetPosition = new Vector3(36.3f, -2.7f, 0);
            break;
            case 11:
            package6.SetActive(false);
            destination6.SetActive(true);
            pointer.targetPosition = new Vector3(-14.8f, 58.7f, 0);
            break;
            case 12:
            destination6.SetActive(false);
            package7.SetActive(true);
            pointer.targetPosition = new Vector3(35.2f, -13.9f, 0);
            break;
            case 13:
            package7.SetActive(false);
            destination7.SetActive(true);
            pointer.targetPosition = new Vector3(7.3f, 4f, 0);
            break;
            case 14:
            destination7.SetActive(false);
            package8.SetActive(true);
            pointer.targetPosition = new Vector3(41.7f, 6.7f, 0);
            break;
            case 15:
            package8.SetActive(false);
            destination8.SetActive(true);
            pointer.targetPosition = new Vector3(-48.5f, -60.4f, 0);
            break;
            case 16:
            destination8.SetActive(false);
            package9.SetActive(true);
            pointer.targetPosition = new Vector3(27.8f, -61f, 0);
            break;
            case 17:
            package9.SetActive(false);
            destination9.SetActive(true);
            pointer.targetPosition = new Vector3(38.8f, 7.4f, 0);
            break;
            case 18:
            destination9.SetActive(false);
            package10.SetActive(true);
            pointer.targetPosition = new Vector3(7.4f, 3.6f, 0);
            break;
            case 19:
            package10.SetActive(false);
            destination10.SetActive(true);
            pointer.targetPosition = new Vector3(-44.2f, -2.4f, 0);
            break;
            case 20:
            destination10.SetActive(false);
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