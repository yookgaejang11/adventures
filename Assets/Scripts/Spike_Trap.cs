using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Trap : TrapDamage
{
    Vector3 basPosition;
    Rigidbody rigid;
    public bool canUp = true;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        basPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveSpike());
    }

    IEnumerator MoveSpike()
    {
        if (canUp)
        {
            canUp = false;
           
            yield return new WaitForSeconds(1f);
            rigid.velocity = Vector3.up * 5;
            yield return new WaitUntil(() => this.transform.position.y >= basPosition.y + 1.8f);
            rigid.velocity = Vector3.zero;
            yield return new WaitForSeconds(1f);

            rigid.velocity = Vector3.down * 5;
            yield return new WaitUntil(() => this.transform.position.y <= basPosition.y);
            rigid.velocity = Vector3.zero;
            canUp = true;
        }
        

    }
}
