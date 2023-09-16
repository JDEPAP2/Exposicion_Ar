using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{   private bool isDragging = false;
    private Vector3 offset;
    private void Update()
    {
        if (isDragging)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition.z = 10;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            transform.position = worldPosition + offset;
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;

        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
