using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // This script can be applied to anything that needs to do damage, or disappear after a set lifetime

    public int damage = 15;      // amount of damage projectile can do
    public float lifetime = 3f;    // time, in seconds, projectile can live

    public void Start()
    {
        Invoke("expire", lifetime);
    }

    public void goodbye()
    {
        if(this.tag != "Player" && this.tag != "Enemy") Destroy(gameObject);
    }

    public void expire()
    {
        // This allows enemies to disappear after leaving the screen
        if (this.tag != "Player") Destroy(gameObject);
    }

    public int GetDamage()
    {
        return damage;
    }
}
