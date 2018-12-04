using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public List<Config> configs;
    int startConfig = 0;

    public void Start()
    {
        var currentConfig = configs[startConfig];
        StartCoroutine(SpawnAllEnemyInConfig(currentConfig));
    }
    private IEnumerator SpawnAllEnemyInConfig(Config config)
    {
        for(int enemyCount=0;enemyCount< config.GetNumberOfEnemyShip();enemyCount++)
        {
        Instantiate(config.GetEnemyShipPrefab(), config.GetWayPoints()[0].transform.position,
            Quaternion.identity);
        yield return new WaitForSeconds(config.GetTimeBetweenShip());
        }


    }
    

}
