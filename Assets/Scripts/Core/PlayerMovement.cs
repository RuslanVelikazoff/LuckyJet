using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody rigidbody;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            rigidbody.AddForce(new Vector3(0, 50, 0), ForceMode.Acceleration);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rigidbody.velocity *= .25f;
        }
    }
}
