using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="Map Data", menuName ="MapData/Map Data")]
public class MapData : ScriptableObject
{
    public Grid grid;

    public Tilemap theMap;

    public List<Vector3Int> mapPositions = new List<Vector3Int>();

    public Dictionary<Vector3Int, bool> mapDictionary = new Dictionary<Vector3Int, bool>();

    private void OnValidate()
    {
        foreach(Vector3Int pos in theMap.cellBounds.allPositionsWithin)
        {
            if(theMap.HasTile(pos))
            {
                mapPositions.Add(pos);
                mapDictionary.Add(pos, true);
            }
        }
    }
}
