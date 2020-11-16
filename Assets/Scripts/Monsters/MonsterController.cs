using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : SingletonMonobehaviour<MonsterController>
{
    public List<Vector3Int> currentSpawnPoints;

    public float spawnerCounter = 0;

    private void Start()
    {
        currentSpawnPoints = MapManager.Instance.MonsterPoints();
        spawnerCounter = Settings.MonsterSpawnTime;
    }

    public Vector3Int GetRandomPoint()
    {
        return currentSpawnPoints[Random.Range(0, currentSpawnPoints.Count)];
    }

    private void Update()
    {
        spawnerCounter -= Time.deltaTime;
        if(spawnerCounter <= 0f)
        {
            Debug.LogError("SpawnMonster " + GetRandomPoint());
            spawnerCounter = Settings.MonsterSpawnTime;
        }
    }
}
