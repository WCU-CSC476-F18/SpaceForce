using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Config config;
    public List<Transform> wayPoints;
    public float moveSpeed = 2f;
    int wayPointIndex = 0;

    //code from martinel////////////////////////////////
    GameObject muzzleFlash;
    private bool hasFired = false;

    public bool canMove = true;
    public float shieldHealth = 50;
    public GameObject bullet;
    public float bulletSpeed = 30f; // speed of bullets
     ///////////////////////////////////////////////////

    int count = 0;
    public void Start()
    {
        wayPoints = config.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
        muzzleFlash = this.transform.Find("MuzzleFlash").gameObject;

    }

    public void Update()
    {
        if (canMove)
            MoveEnemy();
    }

    public void MoveEnemy()
    {
        // Handles user movement and firing

        // Listen for player input and FIRE

       
        if (!hasFired)
        { 
            fire();
            Invoke("resetFire", 2f);
            hasFired = true;
        }








        if (wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisObject = moveSpeed * Time.deltaTime;
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
        GameObject shot = Instantiate(bullet, muzzleFlash.transform.position, bullet.transform.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -bulletSpeed);
       
    }
}
