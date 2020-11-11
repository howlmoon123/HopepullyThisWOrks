[System.Serializable]
public class GridPropertyDetails 
{
    public int gridX;
    public int gridY;
    public bool isDiggable = false;
    public bool canDropItem = false;
    public bool canPlaceFurniture = false;
    public bool isPath = false;
    public bool isNPCObstacle = false;
    public bool canSpawnMonsters = false;

    public GridPropertyDetails() { }
}
