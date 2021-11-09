using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public float ZoomSize;
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        transform.localScale = new Vector3(ZoomSize, ZoomSize, 1.0f);
    }
    
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        transform.localScale = Vector3.one;
    }
}
