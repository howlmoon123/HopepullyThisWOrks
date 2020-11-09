using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="TileData", menuName ="Tile/TileData")]
public class TileData : ScriptableObject
{

    public TileBase[] tiles;


    public float walkingSpeed, posionious;

}
