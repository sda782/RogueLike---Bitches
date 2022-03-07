using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnItemClick : MonoBehaviour
{
    public void OnClick(BaseEventData data)
    {
        PointerEventData pData = (PointerEventData)data;
        PlayerInventory.ShowInfo(pData.pointerClick.gameObject);
    }
}
