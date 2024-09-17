using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoader : MonoBehaviour
{
    [SerializeField] GameObject recipeCanvas;
    bool isVisible = false;

    public void OnMouseDown()
    {
        if(!isVisible)
        {
            recipeCanvas.SetActive(true);
            isVisible = true;
        }

        else if(isVisible)
        {
            recipeCanvas.SetActive(false);
            isVisible = false;
        }
    }
}
