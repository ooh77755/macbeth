using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoader : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    bool isVisible = false;

    public void OnMouseDown()
    {
        if(!isVisible)
        {
            canvas.SetActive(true);
            isVisible = true;
        }

        else if(isVisible)
        {
            canvas.SetActive(false);
            isVisible = false;
        }
    }
}
