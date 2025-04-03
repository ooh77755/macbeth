using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(Draggable card)
    {
        Destroy(card.gameObject);
        card.transform.position = transform.position;
        print("placed");
    }
}
