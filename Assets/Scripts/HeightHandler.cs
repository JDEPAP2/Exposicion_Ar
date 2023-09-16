using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightHandler : MonoBehaviour
{
    public GameObject plane;
    void Update()
    {
        plane.transform.position = new Vector3(plane.transform.position.x, transform.position.y, plane.transform.position.z);
    }
}
