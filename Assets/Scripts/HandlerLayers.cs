using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HandlerLayers : MonoBehaviour
{
    public bool complete = false;
    public int actualLayer = 0;
    public LoadEscene lEsc;
    public Text txt;

    public void Empezar()
    {
        StartCoroutine(StartPuzzle());
    }

    private void Update()
    {
        if (complete)
        {
            actualLayer++;
            complete = false;
        }
        if(actualLayer > 4)
        {
            StartCoroutine(Winning());
        }
    }

    private IEnumerator Winning()
    {
        txt.text = "Ganaste, demostraste tu determinación";
        yield return new WaitForSeconds(5f);
        lEsc.LoadByName("Face");
    }

    private IEnumerator StartPuzzle()
    {
        yield return new WaitForSeconds(5f);
        complete = true;
    }

}
