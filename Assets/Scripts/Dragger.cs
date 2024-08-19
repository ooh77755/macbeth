using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private Vector3 dragOffset;
    private float speed = 10f;
    private Vector3 originalPos;

    [SerializeField] Camera cam;

    private bool isDragging = false;

    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void Start()
    {
        originalPos = transform.position;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
        isDragging = true;

    }    

    private void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + dragOffset, speed * Time.deltaTime);
    }

    private void Update()
    {
        print(isDragging);
        if(Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            StartCoroutine(SnapBackToOriginalPos());
        }
    }

    IEnumerator SnapBackToOriginalPos()
    {
        while(Vector3.Distance(transform.position, originalPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = originalPos;

    }
}
