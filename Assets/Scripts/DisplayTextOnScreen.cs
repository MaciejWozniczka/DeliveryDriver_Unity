using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTextOnScreen : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    [SerializeField] public GameObject message;
    private void Start()
    {
        StartCoroutine(HideTextAfterDelay());
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        textUI.text = "";
        textUI.enabled = false;
        message.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("Game started!");
        textUI.text = "Zbierz wszystkie paczki i zawieź w miejsca docelowe!";
    }
}
