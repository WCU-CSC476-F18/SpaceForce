using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public List<Config> configs;
    public int startConfig = 0;
    public bool loop = true;

    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        do
        {
            yield return StartCoroutine(SpawnAllEnemy());
        } while (loop);
    }

    //public IEnumerator Start()
    //{
    //    do
    //    {
    //        yield return StartCoroutine(SpawnAllEnemy());
    //    } while (loop);
    //}
    private IEnumerator SpawnAllEnemy()
    {
        for(int Index = startConfig; Index< configs.Count; Index++)
        {
            var currentConfig = configs[Index];
            yield return StartCoroutine(SpawnAllEnemyInConfig(currentConfig));
        }
    }
    private IEnumerator SpawnAllEnemyInConfig(Config config)
    {
        for(int enemyCount=0;enemyCount< config.GetNumberOfEnemyShip();enemyCount++)
        {
            GameObject enemy = config.GetEnemyShipPrefab();
            var newEnemy = Instantiate(enemy, config.GetWayPoints()[0].transform.position,
            enemy.transform.rotation);
            newEnemy.GetComponent<Enemy>().SetConfig(config);
            yield return new WaitForSeconds(config.GetTimeBetweenShip());

        }


    }
    

}
