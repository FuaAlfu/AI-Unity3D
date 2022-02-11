using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.2.9
/// </summary>

public class CCCameraFollwo : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    void LateUpdate()
    {
        //using lateupdate to..
        //follow slowly, smoothly  and to prevent jittery
        Vector3 offSet = new Vector3(0, 0, -10);
        transform.position = target.transform.position + offSet;
    }
}
