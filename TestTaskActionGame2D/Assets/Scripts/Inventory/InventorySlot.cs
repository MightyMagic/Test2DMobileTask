using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public int quantity;
    public Item item;

    [SerializeField] TextMeshProUGUI quantityText;
    [SerializeField] Image image;

    [SerializeField] Button deleteButton;


    private void Start()
    {
        ClearSlot();
    }

    public void UpdateInfo(Item item, int quantity)
    {
        this.quantity = quantity;
        this.item = item;

        quantityText.text = quantity.ToString();
        image.sprite = item.itemImage;
    }

    public void ClearSlot()
    {
        item = null;
        quantity = 0;

        image.sprite = null;

        quantityText.text = string.Empty;
        deleteButton.gameObject.SetActive(false);
    }

    public void OnPressed()
    {
        if (quantity > 0)
        {
            deleteButton.gameObject.SetActive(true);
        }
    }

    public void RemoveAnItem()
    {
        if (quantity > 1)
        {
            quantity--;
            UpdateInfo(item, quantity);
        }
        else if(quantity == 1) 
        {
            ClearSlot();
        }
    }
}
