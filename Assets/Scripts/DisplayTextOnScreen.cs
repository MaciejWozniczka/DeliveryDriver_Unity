using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextOnScreen : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public float hideDelay = 5f;

    private void Start()
    {
        StartCoroutine(HideTextAfterDelay());
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);
        textUI.enabled = false;
    }

    void Update()
    {
        textUI.text = "Zbierz wszystkie paczki i zawieź w miejsca docelowe!";
    }
}
