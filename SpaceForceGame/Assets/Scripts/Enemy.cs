using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public List<Transform> wayPoints;
    public float moveSpeed = 2f;
    int wayPointIndex = 0;



    public void Start()
    {
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    public void Update()
    {
        MoveEnemy();
    }

    public void MoveEnemy()
    {
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
}
