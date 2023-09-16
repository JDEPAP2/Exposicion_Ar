using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerGravity : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Main"))
        {
            Rigidbody r = other.gameObject.GetComponentInChildren<Rigidbody>();
            r.useGravity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Main"))
        {
            Rigidbody r = other.gameObject.GetComponentInChildren<Rigidbody>();
            r.useGravity = false;
        }
    }
}
