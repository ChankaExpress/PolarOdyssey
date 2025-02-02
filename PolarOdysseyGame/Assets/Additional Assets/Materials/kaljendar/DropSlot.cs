using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public int correctIndex; // Indeks koji je ispravan za ovaj slot

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null)
        {
            droppedObject.transform.SetParent(transform);
            droppedObject.transform.position = transform.position;

            CheckOrder();
        }
    }

    void CheckOrder()
    {
        // Dobij sve slotove i provjeri da li su elementi na pravim mestima
        DropSlot[] slots = FindObjectsOfType<DropSlot>();
        bool isCorrect = true;

        for (int i = 0; i < slots.Length; i++)
        {
            Transform child = slots[i].transform.childCount > 0 ? slots[i].transform.GetChild(0) : null;

            if (child == null || child.GetComponent<DraggableItem>().itemIndex != slots[i].correctIndex)
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("Correct Order!");
        }
    }
}
