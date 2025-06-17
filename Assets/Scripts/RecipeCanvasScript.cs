using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject ingredients;

    private void OnEnable()
    {
        BoxCollider2D[] allBoxCols = ingredients.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D boxCol in allBoxCols)
        {
            boxCol.enabled = false;
        }
    }

    private void OnDisable()
    {
        BoxCollider2D[] allBoxCols = ingredients.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D boxCol in allBoxCols)
        {
            boxCol.enabled = true;
        }
    }
}
