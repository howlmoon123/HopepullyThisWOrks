using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="TileData", menuName ="TileData/TileData_Mine")]
public class TileData : ScriptableObject
{

    public TileBase[] tiles;


    public float walkingSpeed, posionious;

}
