using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotationGyro : MonoBehaviour
{

    private Gyroscope gyroscope;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }
        else
        {
            Debug.LogError("El dispositivo no admite giroscopio.");
        }
    }

    void Update()
    {
        if (gyroscope != null)
        {
            Quaternion gyroRotation = gyroscope.attitude;

            transform.rotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyroRotation.x*100, -gyroRotation.y*100, gyroRotation.z * 100, gyroRotation.w * 100));
        }
    }
}
