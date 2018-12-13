using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Config config;
    public List<Transform> wayPoints;
    int wayPointIndex = 0;

    //code from martinel////////////////////////////////
    GameObject muzzleFlash;
    private bool hasFired = false;

    public bool canMove = true;
    public float shieldHealth = 50;
    public float flashTime = 0.2f;
    public GameObject Bullet;
    public GameObject Explosion;
    public float bulletSpeed = 30f; // speed of bullets
     ///////////////////////////////////////////////////

     //sound
    public AudioClip shootSound;
    public AudioClip enemyDeathSound;
    //shotcounter
    public float shotCounter;
    public float minTimeBetweenShot = 0.2f;
    public float maxTimeBetweenShot = 5f;
    //explosion
    public GameObject shootHitExplosion;


    public void Start()
    {
        wayPoints = config.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
        shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);
        muzzleFlash = this.transform.Find("MuzzleFlash").gameObject;
        

    }

    public void Update()
    {
        if (canMove)
            MoveEnemy();
        
    }

    public void SetConfig(Config setConfig)
    {
        this.config = setConfig;
    }


    public void MoveEnemy()
    {
        // Handles user movement and firing

        // Listen for player input and FIRE

       
        if (!hasFired)
        {
            muzzleFlash.SetActive(true);
            fire();
            Invoke("resetFire", shotCounter);
            Invoke("killFlash", flashTime);
            hasFired = true;
        }








        if (wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisObject = config.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisObject);

            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void resetFire()
    {
        hasFired = false;
    }
    private void fire()
    {
        GameObject shot = Instantiate(Bullet, muzzleFlash.transform.position, Bullet.transform.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -bulletSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position,0.1f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet damage = collision.gameObject.GetComponent<Bullet>();
        CheckHit(damage);
       
    }

    private void CheckHit(Bullet damage)
    {
        shieldHealth -= damage.GetDamage();
        Instantiate(shootHitExplosion, transform.position, transform.rotation);
        damage.goodbye();
        if (shieldHealth <= 0)
        {
            EnemyDie();
        }
    }


    private void EnemyDie()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(enemyDeathSound,Camera.main.transform.position);
    }

    private void killFlash()
    {
        muzzleFlash.SetActive(false);
    }
}
