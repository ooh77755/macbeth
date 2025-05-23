using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Collider2D col;
    Vector3 startDragPos;
    SpriteRenderer sR;
    int sortingOrder;

    public bool isCorrectItem;
    public static bool IsDragging { get; private set; }

    public GameObject linkedImage;


    private void Start()
    {
        linkedImage.SetActive(false);
        col = GetComponent<Collider2D>();
        sR = GetComponent<SpriteRenderer>();
        sortingOrder = sR.sortingOrder;
    }

    private void OnMouseDown()
    {
        IsDragging = true;
        startDragPos = transform.position;
        sR.sortingOrder = 20;
        transform.position = GetMousePositionInWorldSpace();
        linkedImage.SetActive(true);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace(); 
    }

    private void OnMouseUp()
    {
        IsDragging = false;
        linkedImage.SetActive(false);
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
