using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAxe : MonoBehaviour
{
    public GameObject Target;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Target.transform.position, new Vector3(0,0,1), rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("spin"))
        {
            rotateSpeed *= -1;
        }
    }
}
