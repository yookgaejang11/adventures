using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public int damage = 3;
    public bool isAttack = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isAttack)
        {
            isAttack = true;
            other.gameObject.GetComponent<Enemy>().OnDamage(damage);
            isAttack = false;
        }
    }
}
