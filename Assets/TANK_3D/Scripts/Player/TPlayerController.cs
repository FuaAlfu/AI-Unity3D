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
    private GameObject tankTurret;

    [SerializeField]
    private float currentSpeed, targetSpeed, rotationSpeed, maxForwardSpeed, maxBackwardSpeed;

    private Transform _turret;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 150f;
        maxForwardSpeed = 15f;
        maxBackwardSpeed = -10f;

        _turret = tankTurret.transform;
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        TurretRotate();
    }

    private void TurretRotate()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(playerPlane.Raycast(ray,out float hit))
        {
            Vector3 hitPosition = ray.GetPoint(hit);
            Quaternion newRotation = Quaternion.LookRotation(hitPosition - transform.position);
            _turret.rotation = Quaternion.Slerp(_turret.rotation, newRotation, Time.deltaTime * 10f);
        }
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
