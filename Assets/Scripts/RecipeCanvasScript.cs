using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject ingredients;

    private void Update()
    {
        if(this.enabled)
        {
            BoxCollider2D[] allBoxCols = ingredients.GetComponentsInChildren<BoxCollider2D>();
            foreach(BoxCollider2D boxCol in allBoxCols)
            {
                boxCol.enabled = false;
            }
        }
    }
}
