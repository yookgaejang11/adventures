using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCar : MonoBehaviour
{
    public float rotateSpeed;

    private void Start()
    {
        // 랜덤 회전 속도 지정
        rotateSpeed = Random.Range(150,200f);
    }

    private void Update()
    {
        // 풍차 회전
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
    }

  
}
