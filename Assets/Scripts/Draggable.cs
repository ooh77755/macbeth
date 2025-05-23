using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Collider2D col;
    Vector3 startDragPos;

    SpriteRenderer sR;
    int sortingOrder;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        sR = GetComponent<SpriteRenderer>();
        sortingOrder = sR.sortingOrder;
    }

    private void OnMouseDown()
    {
        startDragPos = transform.position;
        sR.sortingOrder = 20;
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace(); 
    }

    private void OnMouseUp()
    {
        sR.sortingOrder = sortingOrder;
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if(hitCollider != null && hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
        {
            cardDropArea.OnCardDrop(this);
        }
        else
        {
            transform.position = startDragPos;
        }
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }
}
