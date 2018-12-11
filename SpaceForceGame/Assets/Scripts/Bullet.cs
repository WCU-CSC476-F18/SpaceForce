using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // This script can be applied to anything that needs to do damage, or disappear after a set lifetime

    public float damage = 15f;      // amount of damage projectile can do
    public float lifetime = 3f;    // time, in seconds, projectile can live

    void Start()
    {
        Invoke("goodbye", lifetime);
    }

    void goodbye()
    {
        Destroy(this.gameObject);
    }
}
