using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCar : MonoBehaviour
{
    public float rotateSpeed;

    private void Start()
    {
        // ���� ȸ�� �ӵ� ����
        rotateSpeed = Random.Range(150,200f);
    }

    private void Update()
    {
        // ǳ�� ȸ��
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
    }

  
}
