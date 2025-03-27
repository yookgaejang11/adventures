using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public List<GameObject> tests = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        tests[2].transform.SetSiblingIndex(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
