using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private Vector3 dragOffset;
    private float speed = 10f;

    [SerializeField] Camera cam;

    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + dragOffset, speed * Time.deltaTime);
    }
}
