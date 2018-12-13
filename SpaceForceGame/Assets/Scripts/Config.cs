using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Enemy Config")]
public class Config : ScriptableObject {
    public GameObject enemyShipPrefab;
    public GameObject enemyMovingPrefab;
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
        foreach(Transform child in enemyMovingPrefab.transform)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

    public GameObject GetEnemyMovingPrefab()
    {
        return enemyMovingPrefab;
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
