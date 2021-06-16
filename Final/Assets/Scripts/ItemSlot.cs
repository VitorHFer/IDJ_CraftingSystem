using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public Item currentItem;
    public Image itemImage;
    public RectTransform itemTransform;


    private CanvasGroup cg;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        if (currentItem != null)
        {
            itemImage.sprite = currentItem.icon;
        }
        else
        {
            itemImage.sprite = null;
        }

        itemTransform.anchoredPosition = Vector3.zero;
    }
  

   

    public void OnPointerDown(PointerEventData eventData)
    {
        cg.blocksRaycasts = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bool foundSlot = false;

        foreach(GameObject overObj in eventData.hovered)
        {
            if(overObj != gameObject)
            {
                if (overObj.GetComponent<ItemSlot>())
                {
                    ItemSlot itemSlot = overObj.GetComponent<ItemSlot>();

                    Item prevItem = currentItem;

                    currentItem = itemSlot.currentItem;
                    itemSlot.currentItem = prevItem;

                    itemSlot.itemTransform.anchoredPosition = Vector3.zero;
                    itemSlot.UpdateSlot();
                    UpdateSlot();

                    foundSlot = true;
                }
            }
        }

        if (!foundSlot)
        {
            itemTransform.anchoredPosition = Vector3.zero;
        }

        cg.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
       if(currentItem != null)
        {
            itemTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}
