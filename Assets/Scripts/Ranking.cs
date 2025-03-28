using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public List<Text> rankList = new List<Text>();
    public List<float> clearTime = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        clearTime.Sort();

        for (int i = 0; i < rankList.Count; i++)
        {
            rankList[i].text =  clearTime[i].ToString() + "s";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
