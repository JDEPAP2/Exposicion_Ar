using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Rotate : MonoBehaviour
{
    float angle = 180, vel = 5;
    public CambioCara cc;
    public GameObject trueLight;
    public TextMeshProUGUI txt;
    public List<GameObject> panels;

    void Start()
    {
        StartCoroutine(HandleVel());
    }

    void Update()
    {
        if (angle > 355 || angle < 5)
        {
            cc.cambioTextura();
            angle = 0;
        }
        float tAngle = 90f * Time.deltaTime * vel;
        transform.RotateAround(transform.parent.position, transform.parent.up, tAngle);
        angle += tAngle;
    }



    private IEnumerator HandleVel()
    {
        float time = 10;
        for (int i= 0; i < time; i++)
        {
            txt.text = txt.text == "Buscando..." ? "Buscando.." : "Buscando...";
            yield return new WaitForSeconds(1.0f);
            vel-= 0.5f;
        }

        yield return new WaitForSeconds(1.0f);
        
        trueLight.SetActive(true);
        panels[0].SetActive(false);
           
        yield return new WaitForSeconds(2.0f);
        panels[cc.indexMascara + 1].SetActive(true);
        gameObject.SetActive(false);
    }
}
