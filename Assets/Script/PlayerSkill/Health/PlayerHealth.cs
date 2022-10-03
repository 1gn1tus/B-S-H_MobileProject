using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamage
{
    public float playerHp;

    public void ITakeDamage(float damage)
    {
        this.playerHp = this.playerHp - damage;
    }
}
