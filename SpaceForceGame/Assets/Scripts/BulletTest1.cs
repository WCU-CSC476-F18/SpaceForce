using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest1 : MonoBehaviour {

    // This script can be applied to anything that needs to do damage, or disappear after a set lifetime

    public int damage = 15;      // amount of damage projectile can do
    public float lifetime = 3f;    // time, in seconds, projectile can live

    public void Start()
    {
        Invoke("goodbye", lifetime);
    }

    public void goodbye()
    {
        Destroy(this.gameObject);
    }

    public int GetDamage()
    {
        return damage;
    }
}
