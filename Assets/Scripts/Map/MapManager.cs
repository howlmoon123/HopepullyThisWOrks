using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
    [SerializeField] Tilemap map;

    [SerializeField]
    List<TileData> tileDatas;

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += GetMapData;
    }
    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= GetMapData;
    }


    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        

    }

   private void GetMapData()
    {
        Tilemap npcMap = GameObject.FindGameObjectWithTag(Tags.NPCMovementPoints).GetComponent<Tilemap>();
        Tilemap monsterSpawnMap = GameObject.FindGameObjectWithTag(Tags.MonsterSpawnPoints).GetComponent<Tilemap>();

       
    }
}
