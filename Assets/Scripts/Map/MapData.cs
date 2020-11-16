using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

[CreateAssetMenu(fileName ="Map Data", menuName ="MapData/Map Data")]
public class MapData : ScriptableObject
{
   
    public GameObject theMap;

    public List<Vector3Int> mapPositions = new List<Vector3Int>();

    public Dictionary<Vector3Int, bool> mapDictionary = new Dictionary<Vector3Int, bool>();

    public void BuildData()
    {
        Grid grid = theMap.GetComponent<Grid>();

        List<Tilemap> maps = grid.GetComponentsInChildren<Tilemap>().ToList();

        Tilemap waterMap = maps.Find(x => x.gameObject.tag == Tags.PlayerMovementProperties);

        foreach (Vector3Int pos in waterMap.cellBounds.allPositionsWithin)
        {
            if (waterMap.HasTile(pos))
            {
                mapPositions.Add(pos);
                mapDictionary.Add(pos, true);
            }
        }
        Debug.LogError("SO Ran");
    }
}
