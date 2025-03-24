using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public int damage = 2;
    public bool isAttack = true;
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Damage(damage));
        }

    }

    public IEnumerator Damage(int damage)
    {
        
       
        if (isAttack)
        {
            isAttack = false;
            Debug.Log("daf");
            GameObject.Find("Player").GetComponent<Player>().SetHp(damage);
;        }
        yield return new WaitForSeconds(0.1f);
        isAttack = true;
    }
}
