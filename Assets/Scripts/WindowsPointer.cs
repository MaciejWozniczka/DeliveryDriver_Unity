using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unity.VisualScripting;

public class WindowsPointer : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    public Vector3 targetPosition;
    private RectTransform pointerRectTransform;

    private void Start()
    {
        targetPosition = new Vector3(-7.8f, 3.6f, 0);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    public void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;

        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;

        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        Debug.Log("Pointer: " + targetPosition.x + ", " + targetPosition.y);
    }
}
