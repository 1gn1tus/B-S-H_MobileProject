using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamage
{
    [SerializeField]
    public float Hp;

    public void ITakeDamage(float damage)
    {
        this.Hp = this.Hp - damage;
    }

    private void Update()
    {
        if(this.Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
