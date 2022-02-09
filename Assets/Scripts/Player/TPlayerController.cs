using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.2.9
/// </summary>

public class TPlayerController : MonoBehaviour
{
    [SerializeField]
    private float currentSpeed, targetSpeed, rotationSpeed, maxForwardSpeed, maxBackwardSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 150f;
        maxForwardSpeed = 15f;
        maxBackwardSpeed = -10f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float xValue = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        transform.Translate(xValue, 0, zValue);

        if (Input.GetKey(KeyCode.W))
        {
            targetSpeed = maxForwardSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            targetSpeed = maxBackwardSpeed;
        }
        else
        {
            targetSpeed = 0;
        }

        //rotation
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * 10f);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
