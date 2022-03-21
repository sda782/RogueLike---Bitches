using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private int _enemiesSpawnCount = 5;
    private bool _stopSpawning = false;
    private RoomFirst room;
    [SerializeField]
    private GameObject _enemy;
    private float randomXPosition = Random.Range(0, 10);
    private float randomYPosition = Random.Range(10, 0);

    private void Start()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        RoomFirst rf = GameObject.Find("RoomFirst").GetComponent<RoomFirst>();
        _enemy.transform.position = rf.RoomList[Random.Range(1, rf.RoomList.Count - 1)];
        Debug.Log("Test");
        if (!_stopSpawning)
        {
            Debug.Log("Before For-Loop");
            for (int i = 0; i < _enemiesSpawnCount; i++)
            {
                Debug.Log("In For-Loop");
                Vector3 posToSpawn = new Vector3(Random.Range(randomXPosition, randomYPosition ), rf.RoomList.Count+1, 1);
                GameObject newEnemy = Instantiate(_enemy, posToSpawn, Quaternion.identity);
            }
        }
    }
}
