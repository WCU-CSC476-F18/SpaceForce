using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Enemy Config")]
public class Config : ScriptableObject {
    public GameObject enemyShipPrefab;
    public GameObject enemyMovingPrefab;
    public GameObject[] enemyMovingList; // Optional array of enemy movements to use in sequence
    public bool useList = false;         // Turn this on to use the list of movements
    public float timeBetweenShip = 1f;
    public int numberOfEnemyShip = 4;
    public float moveSpeed = 10f;

    public GameObject GetEnemyShipPrefab()
    {
        return enemyShipPrefab;
    }

    public List<Transform> GetWayPoints()
    {
        var wayPoints = new List<Transform>();
        GameObject movement;
        if (useList)
        {
            movement = enemyMovingList[Random.Range(0, enemyMovingList.Length)];
        }
        else
        {
            movement = enemyMovingPrefab;
        }
        foreach (Transform child in movement.transform)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

    public GameObject GetEnemyMovingPrefab()
    {
        if (useList)
        {
            return enemyMovingList[Random.Range(0,enemyMovingList.Length)];
        }
        else return enemyMovingPrefab;
    }
    public float GetTimeBetweenShip()
    {
        return timeBetweenShip;
    }

    public int GetNumberOfEnemyShip()
    {
        return numberOfEnemyShip;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
