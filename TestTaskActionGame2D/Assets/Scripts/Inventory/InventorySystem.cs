using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] List<InventorySlot> inventorySlots = new List<InventorySlot>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            AcquireNewItem(collision.gameObject.GetComponent<Item>());
        }
    }

    public void AcquireNewItem(Item item)
    {
        for(int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].quantity != 0)
            {
                if(item == inventorySlots[i].item)
                {
                    inventorySlots[i].quantity++;
                    inventorySlots[i].UpdateInfo(item, (inventorySlots[i].quantity));
                    // found the mathcing item
                    return;
                }
            }
        }

        for(int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].quantity == 0)
            {
                inventorySlots[i].UpdateInfo(item, 1);
                return;
            }
        }
    }
}
