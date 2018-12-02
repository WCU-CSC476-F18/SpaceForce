using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Enemy Config")]
public class Config : ScriptableObject {
    [SerializeField] GameObject enemyShipPrefab;
    [SerializeField] GameObject enemyMovingPrefab;
    [SerializeField] float timeBetweenShip = 1f;
    [SerializeField] float shipRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemyShip = 4;
    [SerializeField]  float moveSpeed = 10f;

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

    public float GetShipRandomFactor()
    {
        return shipRandomFactor;
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
