using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float moveSpeed = 5f;


    public void Update()
    {
        Move();
    }

    public void Move()
    {
        var keyBoardX = Input.GetAxis("Horizontal")* Time.deltaTime*moveSpeed;
        var xPos = transform.position.x + keyBoardX;
        var keyBoardY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var yPos = transform.position.y + keyBoardY;
        transform.position = new Vector2(xPos, yPos);
    }
}
