using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.2.9
/// </summary>

public class CCPlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8f;

    [SerializeField]
    private float gravity = 33f;

    Vector3 direction;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
      //  if(Input.GetKeyDown(KeyCode.RightArrow))
        controller.Move(Vector3.right * moveSpeed * Time.deltaTime);
        //controller.Move(Vector3.right * direction * moveSpeed * Time.deltaTime);
    }
}
