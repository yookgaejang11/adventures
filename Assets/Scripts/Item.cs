using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject InventoryImg;
    public int Price;
    public int Weight;
    public bool isPotion = false;

    public void Start()
    {
        if (isPotion)
        {
            InventoryImg = GameManager.Instance.Potions[Random.Range(0, GameManager.Instance.Potions.Count)];
        }
    }
}
