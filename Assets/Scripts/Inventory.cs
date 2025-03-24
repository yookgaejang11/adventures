using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject objDestroy;
    bool selected = false;
    public int currentWeight = 0;
    public int maxWeight = 100;
    public GameObject bag;
    bool isOpen = false;
    public List<GameObject> items = new List<GameObject>();
    public int maxSlot = 4;
    public List<GameObject> slots = new List<GameObject>();
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        bag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(text != null)
        {
            text.text = "¹«°Ô" + currentWeight + "/" + maxWeight;
            if(currentWeight > maxWeight)
            {
                text.color = Color.red;
            }
        }
        if(!isOpen && Input.GetKeyDown(KeyCode.I)) {

            isOpen = true; 
            bag.SetActive(true);
        }
        else if (isOpen && Input.GetKeyDown(KeyCode.I))
        {
            isOpen = false;
            bag.SetActive(false);
        }
    }

    public void InterectItem(GameObject clickedObj)
    {
        if(clickedObj.gameObject.transform.childCount !=0)
        {

            if (clickedObj.gameObject.transform.GetChild(0).CompareTag("Correct_Item"))
            {
                Destroy(clickedObj.gameObject.transform.GetChild(0).gameObject);
            }
            else
            {
                switch(clickedObj.gameObject.transform.GetChild(0).gameObject.tag)
                {
                    case "Hp_Item":
                        {
                            GameObject.Find("Player").GetComponent<Player>().Hp();
                        }
                        break;
                    case "Air_Item":
                        {
                            GameObject.Find("Player").GetComponent<Player>().Air();
                        }
                        break;
                    case "Direct_Item":
                        {
                            GameObject.Find("Player").GetComponent<Player>().ItemDirection();
                        }
                        break;
                    case "Small_Speed_Item":
                        {
                            GameObject.Find("Player").GetComponent<Player>().Small_Speed();
                        }
                        break;
                    case "Speed_Item":
                        {
                            GameObject.Find("Player").GetComponent<Player>().Speed();
                        }
                        break;
                    case "Invisible_Item":
                        {
                            GameObject.Find("Player").GetComponent<Player>().Invisible();
                        }
                        break;

                }
                Destroy(clickedObj.gameObject.transform.GetChild(0).gameObject);
                


            }
            

        }
    }

    public void SetItem(GameObject item)
    {
        for (int i = 0; i < maxSlot; i++)
        {
            if (items[i] == null && !selected)
            {
                items[i] = item;
                GameObject it = Instantiate(items[i].GetComponent<Item>().InventoryImg);
                RectTransform itRt = it.GetComponent<RectTransform>();
                currentWeight += item.GetComponent<Item>().Weight;
                itRt.SetParent(slots[i].GetComponent<RectTransform>());
                itRt.anchoredPosition = Vector3.zero;
                itRt.pivot = new Vector2(0.5f, 0.5f);
                itRt.anchorMax = Vector2.one;
                itRt.anchorMin = Vector2.zero;
                itRt.offsetMin = new Vector2(10, 10);
                itRt.offsetMax = new Vector2(-10, -10);
                selected = true;
            }

        }
        if (maxWeight < currentWeight)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.speed = 2;
        }

        selected = false;



    }


}
