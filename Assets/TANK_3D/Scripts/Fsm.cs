using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.11.7
/// fs machine
/// </summary>
public class Fsm : MonoBehaviour
{
    protected Transform playerTransform;
    protected Vector3 destinationPos;
    protected GameObject[] wonderPoints;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        FMSUpdate();
    }

    protected virtual void Initialize()
    {

    }

    protected virtual void FMSUpdate()
    {

    }
}
