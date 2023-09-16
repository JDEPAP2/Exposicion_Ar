using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Touch;
public class HandlerMove : MonoBehaviour
{
    public LoadEscene lEsc;
    public TextMeshProUGUI txt;
    public GameObject light;
    public List<GameObject> rocks;
    private int index = 0;
    public AudioSource aud;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("roca"))
        {
            if (other.name == "Last")
            {
                light.SetActive(true);
                StartCoroutine(Winning());
                return;
            }
            index++;
            rocks[index - 1].GetComponent<LeanDragTranslate>().enabled = false;
            rocks[index].GetComponent<LeanDragTranslate>().enabled = true;
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
