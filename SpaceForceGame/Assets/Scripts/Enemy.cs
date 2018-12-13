using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    const float bottomBoundary = -12f;

    public Config config;
    public List<Transform> wayPoints;
    int wayPointIndex = 0;

    //code from martinel////////////////////////////////
    GameObject muzzleFlash;
    private bool hasFired = false;

    public bool canMove = true;
    public bool canFire = false;
    public float shieldHealth = 50;
    public float flashTime = 0.2f;
    public GameObject Bullet;
    public GameObject Explosion;
    public float bulletSpeed = 30f; // speed of bullets

    public GameObject[] BulletList; // optional list of bullet objects for larger enemies with multiple guns
    public GameObject[] FlashList;
    // IF YOU USE THIS, MAKE SURE YOU HAVE AT LEAST ONE MUZZLE FLASH FOR EACH BULLET TYPE
    private int bulletIndex = 0;
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
    //addScore
    public int pointScore1 = 1;

    public void Start()
    {
        wayPoints = config.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
        shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);
        if(canFire) muzzleFlash = this.transform.Find("MuzzleFlash").gameObject;
        

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


        // handle the muzzle flash and fire if possible
        if (!hasFired && canFire)
        {
            if (BulletList.Length > 0 && bulletIndex < BulletList.Length && bulletIndex < FlashList.Length)
            {
                FlashList[bulletIndex].SetActive(true);
            }
            else muzzleFlash.SetActive(true);
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
            //Destroy(gameObject);
            wayPointIndex = 1;
        }
    }

    private void resetFire()
    {
        hasFired = false;
    }
    private void fire()
    {
        if (transform.position.y > bottomBoundary)
        {
            GameObject shot;
            if (BulletList.Length > 0 && bulletIndex < BulletList.Length && bulletIndex < FlashList.Length)
            {
                shot = Instantiate(BulletList[bulletIndex], FlashList[bulletIndex].transform.position, Bullet.transform.rotation);
            }
            else shot = Instantiate(Bullet, muzzleFlash.transform.position, Bullet.transform.rotation);
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -bulletSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet damage = collision.gameObject.GetComponent<Bullet>();
        CheckHit(damage);
       
    }

    private void CheckHit(Bullet damage)
    {
        shieldHealth -= damage.GetDamage();
        Instantiate(shootHitExplosion, damage.transform.position, damage.transform.rotation);
        damage.goodbye();
        if (shieldHealth <= 0)
        {
            EnemyDie();
            FindObjectOfType<ConnectObjects>().AddToScore(pointScore1);
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
        if (BulletList.Length > 0 && bulletIndex < BulletList.Length && bulletIndex < FlashList.Length)
        {
            FlashList[bulletIndex].SetActive(false);
            bulletIndex++;
            if (bulletIndex >= BulletList.Length)
                bulletIndex = 0;
        }
        else muzzleFlash.SetActive(false);
    }
}
