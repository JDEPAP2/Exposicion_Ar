using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotationGyro : MonoBehaviour
{
    public HandlerLayers hl;
    public string axis;
    private Gyroscope gyroscope;
    private float angle = 100, time = 2, wTime;
    private Quaternion r;
    public int layer = 1;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            r = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Debug.LogError("El dispositivo no admite giroscopio.");
        }
    }

    void Update()
    {
        if (gyroscope != null && hl.actualLayer == layer)
        {
            Quaternion gyroRotation = gyroscope.attitude;

            switch (axis)
            {
                case "x":
                    angle = gyroRotation.eulerAngles.x*5;
                    transform.rotation = Quaternion.Euler(0,angle, 0);
                    break;
                case "y":
                    angle = gyroRotation.eulerAngles.y*5;
                    transform.rotation = Quaternion.Euler(angle, 0, 0);
                    break;

                case "z":
                    angle = gyroRotation.eulerAngles.z*5;
                    transform.rotation = Quaternion.Euler(0, 0,angle);
                    break;
            }
        }
        if (Quaternion.Angle(transform.rotation, r) <= 0.5)
        {
            wTime += Time.deltaTime;

            if (wTime >= time)
            {
                hl.complete = true;
            }
        }
        else
        {
            wTime = 0;
        }
    }
}
