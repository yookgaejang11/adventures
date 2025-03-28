using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool istime = true;
    public float timer;
    public Text timeobj;
    public int PlayerHp;
    public float PlayerAir;
    private static GameManager instance;
    public List<GameObject> Potions = new List<GameObject>();
    public Slider hp_Slider;
    public Slider air_Slider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex >=2)
        {

            StartCoroutine(Timer());
        }
        hp_Slider.value = (float)GameObject.Find("Player").GetComponent<Player>().currentHp / GameObject.Find("Player").GetComponent<Player>().maxHp;
        air_Slider.value = (float)GameObject.Find("Player").GetComponent<Player>().currentAir / GameObject.Find("Player").GetComponent<Player>().maxAir;
    }

    IEnumerator Timer()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 2 && istime)
        {
            istime = false;
            timeobj.text = (int)(timer / 60) + ":" + (timer % 60);
            yield return new WaitForSeconds(1);
            timer += 1;
            istime = true;
        }
    }

public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
