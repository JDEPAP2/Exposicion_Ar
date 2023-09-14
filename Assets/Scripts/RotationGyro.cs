using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotationGyro : MonoBehaviour
{
    public HandlerLayers hl;
    public string axis;
    private Gyroscope gyroscope;
    private float angle = 100, time = 2, wTime;
    private bool first = true;
    public int layer = 1;
    private Collider c;

    void Start()
    {

        c = transform.GetComponent<Collider>();
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
        if (!c.enabled)
        {
            c.enabled = true;
        }

        if (gyroscope != null && hl.actualLayer == layer)
        {
            Quaternion gyroRotation = gyroscope.attitude;

            switch (axis)
            {
                case "x":
                    angle = gyroRotation.eulerAngles.x*10;
                    transform.rotation = Quaternion.Euler(0,angle, 0);
                    break;
                case "y":
                    angle = gyroRotation.eulerAngles.y*10;
                    transform.rotation = Quaternion.Euler(angle, transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y, transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.z);
                    break;
                case "z":
                    angle = gyroRotation.eulerAngles.z*10;
                    transform.rotation = Quaternion.Euler(transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.x, transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y, angle);
                    break;
            }

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Main"))
        {
            wTime = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Main"))
        {
            Debug.Log("Entro");
            wTime += Time.deltaTime;

            if (wTime >= time && first)
            {
                hl.complete = true;
                first = false;
            }
        }
    }
}
