using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundObject : MonoBehaviour
{
    public Transform pointOfInterest;
    public float cameraRotationSpeed;
    public float cameraDistanceFromObject;
    public float cameraVerticalHeight;
    public float cameraAdditionalXRotation;

    void Start()
    {
        //Set the starting position equal to our target of interest
        transform.position = pointOfInterest.position;
        transform.rotation = new Quaternion(0, 0, 0, 0);

        //Modify our viewing position
        transform.position = new Vector3(transform.position.x, transform.position.y + cameraVerticalHeight, transform.position.z + cameraDistanceFromObject);
        transform.LookAt(pointOfInterest);

        //Rotate around the X axis if a value has been given, allowing the user to fine-tune the angle if needed
        transform.Rotate(cameraAdditionalXRotation, 0, 0);
    }

    void Update()
    {
        transform.RotateAround(pointOfInterest.position, Vector3.up, cameraRotationSpeed * Time.deltaTime);
    }
}
