using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 5;
    public bool isDie;
    public enum EnemyType
    {
        Stoking,
        Basic,
    }
    void Start()
    {
        
    }

    public void OnDamage(int damage)
    {
       if (!isDie)
        {
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
                isDie = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
