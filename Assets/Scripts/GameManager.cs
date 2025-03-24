using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public List<GameObject> Potions = new List<GameObject>();
    public Player player;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp_Slider.value = (float)player.currentHp / player.maxHp;
        air_Slider.value = (float)player.currentAir / player.maxAir;
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
