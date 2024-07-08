using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;

    public List<Item> items = new List<Item>();

    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ItemManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(ItemManager).Name);
                    instance = singletonObject.AddComponent<ItemManager>();

                    DontDestroyOnLoad(singletonObject);
                }
            }

            return instance;
        }
    }

    public Item GenerateRandomItem()
    {
        return items[Random.Range(0, items.Count)];
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
