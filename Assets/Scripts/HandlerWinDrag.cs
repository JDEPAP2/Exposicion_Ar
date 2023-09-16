using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandlerWinDrag : MonoBehaviour
{
    public LoadEscene lEsc;
    public TextMeshProUGUI txt;
    private bool salio;
    public GameObject light;
    public AudioSource aud;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("roca"))
        {
            light.SetActive(true);
            salio = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("roca"))
        {
            light.SetActive(false);
            salio = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (salio && other.CompareTag("Cam"))
        {
            StartCoroutine(Winning());
        }
    }


    private IEnumerator Winning()
    {
        aud.Play();
        txt.text = "Ganaste, demostraste tu determinación";
        yield return new WaitForSeconds(5f);
        lEsc.LoadByName("Face");
    }
}
