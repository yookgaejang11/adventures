using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingPlatForm : MonoBehaviour
{
    public bool isRandom;
    public float rotateSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        if (isRandom)
        {
            rotateSpeed = Random.Range(90, 120);
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
    }
}
