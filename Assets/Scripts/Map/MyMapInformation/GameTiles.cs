using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTiles : SingletonMonobehaviour<GameTiles>
{
	public static GameTiles instance;
	public Tilemap Tilemap;

	public Dictionary<Vector3, WorldTile> tiles;
	public List<WorldTile> worldTiles;

	private void OnEnable()
    {
		EventHandler.AfterSceneLoadEvent += GetWorldTiles;
    }

    // Use this for initialization
    private void GetWorldTiles()
	{
		tiles = new Dictionary<Vector3, WorldTile>();
		foreach (Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
		{
			var localPlace = new Vector3Int(pos.x, pos.y, pos.z);

			if (!Tilemap.HasTile(localPlace)) continue;
			var tile = new WorldTile
			{
				LocalPlace = localPlace,
				WorldLocation = Tilemap.CellToWorld(localPlace),
				TileBase = Tilemap.GetTile(localPlace),
				TilemapMember = Tilemap,
				Name = localPlace.x + "," + localPlace.y,
				Cost = 1 // TODO: Change this with the proper cost from ruletile
			};

			tiles.Add(tile.WorldLocation, tile);
			worldTiles.Add(tile);
		}
	}
}
