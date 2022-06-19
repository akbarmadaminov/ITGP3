using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Vector3 direction = new Vector3(0, 0, 0);
    public int side = 0;
    public float speed = 5;
    public float rotateTime = 0.1f;
    public float rotateSmooth;
    
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude > 0.1)
        {
            transform.position += direction * speed * Time.deltaTime;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotateSmooth, rotateTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
