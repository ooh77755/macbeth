using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour, ICardDropArea
{
    [SerializeField] GameObject steamVFX;
    [SerializeField] Transform child;

    public void OnCardDrop(Draggable card)
    {
        GameManager.Instance.RegisterDrop(card.isCorrectItem);

        GameObject smoke = Instantiate(steamVFX, child.transform.position, Quaternion.identity);
        Destroy(smoke, 2f);
        card.linkedImage.SetActive(true);
        Destroy(card.gameObject);
        card.transform.position = transform.position;
    }
}
