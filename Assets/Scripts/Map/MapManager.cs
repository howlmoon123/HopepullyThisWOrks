using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System.Linq;


public class MapManager : SingletonMonobehaviour<MapManager>
{
    [SerializeField]
    Tilemap waterMap;
    [SerializeField]
    Tilemap monsterSpawnMap;

    List<Vector3Int> monsterPoints = new List<Vector3Int>();

    public Dictionary<Vector3Int, bool> waterLocations;
    public Dictionary<Vector3Int, bool> monsterSpawnPoints;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    //    testWaterData.BuildData();
       // UnityEditor.EditorUtility.SetDirty(testWaterData);
    }

    private void OnEnable()
    {
       // GetMapData();
      // EventHandler.AfterSceneLoadEvent += GetMapData;
      
    }
    private void OnDisable()
    {
       // EventHandler.BeforeSceneUnloadEvent -= GetMapData;
    }



    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(!scene.name.Equals(Settings.PersistentScene))
        GetMapData();
    }


    private void GetMapData()
    {
        waterMap = FindObjectsOfType<Tilemap>().ToList().Find(x => x.gameObject.tag == Tags.isWater);
        monsterSpawnMap = FindObjectsOfType<Tilemap>().ToList().Find(x => x.gameObject.tag == Tags.MonsterSpawnPoints);
        waterLocations = new Dictionary<Vector3Int, bool>();
        monsterSpawnPoints = new Dictionary<Vector3Int, bool>();
       
        foreach(Vector3Int pos in waterMap.cellBounds.allPositionsWithin)
        {
           
            if(waterMap.HasTile(pos))
            {
                waterLocations.Add(pos, true);
            }
           
        }
        foreach(Vector3Int pos in monsterSpawnMap.cellBounds.allPositionsWithin)
        {
            if(monsterSpawnMap.HasTile(pos))
            {
                monsterSpawnPoints.Add(pos, true);
                monsterPoints.Add(pos);
            }
        }

        Debug.LogError("Water Locations " + waterLocations.Count + " Monster Spawn " + monsterSpawnPoints.Count);
    }

    public List<Vector3Int> MonsterPoints()
    {
        return monsterPoints;
    }

    
}
