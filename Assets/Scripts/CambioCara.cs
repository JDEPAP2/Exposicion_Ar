using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class CambioCara : MonoBehaviour
{
    [SerializeField] private ARFaceManager managerCara;
    public List<Material> mascaras = new List<Material>();
    public FuncionesFiltro fn;
    private int indexMascara = 0;

    // Start is called before the first frame update
    void Start()
    {
        managerCara = GetComponent<ARFaceManager>();
    }

    public void cambioTextura()
    {
        indexMascara = new System.Random().Next(0, mascaras.Count);

        foreach (ARFace cara in managerCara.trackables)
        {
            cara.GetComponent<MeshRenderer>().material = mascaras[indexMascara];
        }
        fn.accion = true;
    }
}