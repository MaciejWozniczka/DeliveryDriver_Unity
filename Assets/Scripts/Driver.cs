using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 5f;
    void Start()
    {

    }

    void Update()
    {
        float steerAmount = steerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveAmount = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime * 2;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
