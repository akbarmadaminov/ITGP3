using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;
    
    private float _fixedY;
    private Vector3 _offset;
    private void Awake()
    {
        Vector3 initialPosition = transform.position;
        _offset = initialPosition - FollowTarget.position;
        _fixedY = initialPosition.y;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = FollowTarget.position + _offset;
        newPosition.y = _fixedY;
        transform.position = newPosition;
    }
}