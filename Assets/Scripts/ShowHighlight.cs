using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHighlight : MonoBehaviour
{
    [SerializeField] GameObject silhouette;
    [SerializeField] GameObject canvas;

    private void OnMouseOver()
    {
        silhouette.SetActive(true);
        canvas.SetActive(true);
    }

    private void OnMouseExit()
    {
        silhouette.SetActive(false);
        canvas.SetActive(false);
    }
}
