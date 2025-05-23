//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Dragger : MonoBehaviour
//{
//    private Vector3 dragOffset;
//    private float speed = 10f;
//    private Vector3 originalPos;

//    [SerializeField] Camera cam;

//    private bool isDragging = false;
//    bool isPlaced = false;

//    private void Start()
//    {
//        originalPos = transform.position;
//    }

//    Vector3 GetMousePos()
//    {
//        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
//        mousePos.z = 0;
//        return mousePos;
//    }

//    private void OnMouseDown()
//    {
//        if(!isPlaced)
//        {
//            dragOffset = transform.position - GetMousePos();
//            isDragging = true;
//        }
//    }    

//    private void OnMouseDrag()
//    {
//        if(!isPlaced)
//        {
//            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + dragOffset, speed * Time.deltaTime);
//        }
//    }

//    private void Update()
//    {
//        if(Input.GetMouseButtonUp(0) && isDragging)
//        {
//            isDragging = false;

//            Collider2D dropZone = Physics2D.OverlapPoint(transform.position);
//            if(dropZone!=null && dropZone.CompareTag("DropZone"))
//            {
//                transform.position = dropZone.transform.position;
//                isPlaced = true;
//                dropZone.GetComponent<DropZone>()?.ObjectPlaced();
//            }
//            else
//            {
//                //StartCoroutine(SnapBackToOriginalPos());
//            }
//        }
//    }

//    //IEnumerator SnapBackToOriginalPos()
//    //{
//    //    while(Vector3.Distance(transform.position, originalPos) > 0.01f)
//    //    {
//    //        transform.position = Vector3.MoveTowards(transform.position, originalPos, speed * Time.deltaTime);
//    //        yield return null;
//    //    }

//    //    transform.position = originalPos;
//    //}
//}
