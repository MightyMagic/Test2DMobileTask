using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectible : MonoBehaviour
{
    Item item;

    private void Start()
    {
        item = ItemManager.Instance.GenerateRandomItem();


        GetComponent<SpriteRenderer>().sprite = item.itemImage;
        this.transform.localScale *= 3f;
        //sprite = item.itemImage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<InventorySystem>().AcquireNewItem(item);

            Destroy(this.gameObject);
        }
    }
}
