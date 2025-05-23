using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(Draggable card)
    {
        GameManager.Instance.RegisterDrop(card.isCorrectItem);

        card.linkedImage.SetActive(true);
        Destroy(card.gameObject);
        card.transform.position = transform.position;
    }
}
