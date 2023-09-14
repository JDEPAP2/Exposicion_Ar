using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarRot : MonoBehaviour
{
    public GameObject cam;
    public void Ajustar()
    {
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y - 160, 0);
    }
}
