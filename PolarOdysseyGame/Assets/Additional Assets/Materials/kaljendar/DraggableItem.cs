using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public int itemIndex;  // Indeks itema
    private bool isBeingDragged = false;
    public Vector3 originalPosition;
    private bool isOnCorrectSlot = false;  //jel dobra pozicija?

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isOnCorrectSlot) // Drag ako nije na dobroj poziciji
        {
            isBeingDragged = true;
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isOnCorrectSlot)
        {
            //nista
        }
        else
        {
            // nazad na početnu poziciju ako nije na ispravnom mistu
            transform.position = originalPosition;
        }
        isBeingDragged = false;
    }

    public void SetOnCorrectSlot(bool value)
    {
        isOnCorrectSlot = value;
    }
}
