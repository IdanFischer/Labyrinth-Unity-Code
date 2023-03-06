using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTilt : MonoBehaviour
{
    private Vector3 currentRotation;
    public float HorizontalRotation = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        currentRotation = transform.rotation.eulerAngles;

        if (((Input.GetAxis("Horizontal") > 0.2f)) && (currentRotation.y <= 9.5f || currentRotation.y >= 350.0f))
        {
            transform.Rotate(HorizontalRotation, 0, 0);
        }
        if (((Input.GetAxis("Horizontal") < -0.2f)) && (currentRotation.y <= 10.0f || currentRotation.y >= 350.5f))
        {
            transform.Rotate(-HorizontalRotation, 0, 0);
        }
    }
}