using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLayers : MonoBehaviour
{
    public bool complete = false;
    public int actualLayer = 0;


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
    }

    private IEnumerator StartPuzzle()
    {
        yield return new WaitForSeconds(5f);
        complete = true;

    }

}
