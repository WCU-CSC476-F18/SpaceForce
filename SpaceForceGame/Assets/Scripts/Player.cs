﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // States for bank animations
    const int STATE_IDLE = 0;
    const int STATE_RIGHT = 1;
    const int STATE_LEFT = -1;

    // Y scale values for thrust sprite
    const float THRUST_FULL = 1f;
    const float THRUST_HALF = 0.5f;
    const float THRUST_OFF = 0.25f;

    private Vector2 bounds = new Vector2(7.2f,9.1f);
    Animator animator;
    GameObject exhaust;
    GameObject muzzleFlash;
    private bool hasFired = false;

    public float moveSpeed = 15f;
    public bool canMove = true;
    public float shieldHealth = 100;
    public GameObject bullet;
    public float bulletSpeed = 30f; // speed of bullets

    int _currentState = STATE_IDLE;



    private void Start()
    {
        animator = this.transform.Find("Ship").gameObject.GetComponent<Animator>();
        exhaust = this.transform.Find("Exhaust").gameObject;
        muzzleFlash = this.transform.Find("MuzzleFlash").gameObject;
       
    }

    public void Update()
    {
        if(canMove)
            Move();
    }

    public void Move()
    {
        // Handles user movement and firing

        // Listen for player input and FIRE
        if (Input.GetButton("Fire1"))
        {
            muzzleFlash.SetActive(true);
            if(!hasFired)
            {
                fire();
                Invoke("resetFire", 0.1f);
                hasFired = true;
            }
        }
        else
            muzzleFlash.SetActive(false);

        // Calculate new location
        var keyBoardX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var xPos = transform.position.x + keyBoardX;
        var keyBoardY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var yPos = transform.position.y + keyBoardY;

        // Play Right/Left banking animation
        if (Input.GetAxisRaw("Horizontal") > 0)
            setState(STATE_RIGHT);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            setState(STATE_LEFT);
        else
            setState(STATE_IDLE);

        // Increase/Decrease thrust
        if (Input.GetAxisRaw("Vertical") > 0)
            exhaust.transform.localScale = new Vector3(1, THRUST_FULL, 1);
        else if (Input.GetAxisRaw("Vertical") < 0)
            exhaust.transform.localScale = new Vector3(1, THRUST_OFF, 1);
        else
            exhaust.transform.localScale = new Vector3(1, THRUST_HALF, 1);

        // Don't leave the play field
        if (xPos > bounds.x)
            xPos = bounds.x;
        else if (xPos < -bounds.x)
            xPos = -bounds.x;
        if (yPos > bounds.y)
            yPos = bounds.y;
        else if (yPos < -bounds.y)
            yPos = -bounds.y;

        // Update location
        transform.position = new Vector2(xPos, yPos);
    }

    // Helper function for playing animations via state change
    void setState(int state)
    {
        if (_currentState == state)
            return;

        animator.SetInteger("state", state);
        _currentState = state;
    }

    private void resetFire()
    {
        hasFired = false;
    }

    private void fire()
    {
        GameObject shot = Instantiate(bullet, muzzleFlash.transform.position, bullet.transform.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, bulletSpeed);
    }


}