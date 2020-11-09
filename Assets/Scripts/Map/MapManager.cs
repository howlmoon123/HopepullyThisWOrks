using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
    [SerializeField] Tilemap map;

    [SerializeField]
    List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tiledata in tileDatas)
        {
            foreach (var tile  in tiledata.tiles)
            {
                dataFromTiles.Add(tile, tiledata);
            }
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePos);

            TileBase clickedTile = map.GetTile(gridPosition);

            float walkingSpeed = dataFromTiles[clickedTile].walkingSpeed;

            Debug.LogError("TIle " + gridPosition + " there is a clicked tile " + walkingSpeed);
        }
    }
}
