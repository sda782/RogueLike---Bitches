using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private int _enemiesSpawnCount = 3;
    //private RoomFirst room;
    [SerializeField]
    private GameObject _enemy;


    private void Start()
    {
        if (PlayerStats.EnemiesPrRoom == 0) PlayerStats.EnemiesPrRoom = _enemiesSpawnCount;
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        //RoomFirst rf = GameObject.Find("RoomFirst").GetComponent<RoomFirst>();
        //_enemy.transform.position = rf.RoomList[Random.Range(1, rf.RoomList.Count - 1)];
        int rng = Random.Range(PlayerStats.EnemiesPrRoom - 2, PlayerStats.EnemiesPrRoom);
        for (int i = 0; i < rng; i++)
        {
            float randomXPosition = Random.Range(0, 3);
            float randomYPosition = Random.Range(0, 3);
            Vector3 randomPos = new Vector3(randomXPosition, randomYPosition, 0);
            Vector2 spawnLocation = transform.localPosition + randomPos;
            Instantiate(_enemy, spawnLocation, Quaternion.identity);
        }

    }
}
