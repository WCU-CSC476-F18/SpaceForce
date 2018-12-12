using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public int damage = 100;      // amount of damage projectile can do

    public void Hit()
    {
        Destroy(gameObject);
    }

    public int GetDamage()
    {
        return damage;
    }
}
