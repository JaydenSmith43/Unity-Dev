using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField][Range(20, 90)] float defaultPitch = 20;
    [SerializeField][Range(1, 10)] float distance = 5;
    [SerializeField][Range(0.1f, 2.0f)] float sensitivity = 1;

    float yaw = 0;
    float pitch = 0;

    private void Start()
    {
        pitch = defaultPitch;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        Quaternion qYaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qPitch = Quaternion.AngleAxis(defaultPitch, Vector3.right);
        Quaternion rotation = qYaw * qPitch;
        
        transform.position = target.position + (rotation * Vector3.back * distance);
        transform.rotation = rotation;
    }
}
