using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float speedUp = 1f;
    [SerializeField] GameObject nitro;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Vertical") == 1)
        {
            float steerAmount = steerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
        }
        else if (Input.GetAxis("Vertical") == -1)
        {
            float steerAmount = steerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            transform.Rotate(0, 0, steerAmount);
        }

        float moveAmount = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime * (Input.GetAxis("Jump") + speedUp);
        transform.Translate(0, moveAmount, 0);

        nitro.SetActive(Input.GetButton("Jump"));
    }
}
