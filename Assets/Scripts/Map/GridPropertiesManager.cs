using System.Collections.Generic;
using UnityEngine;

public class GridPropertiesManager : MonoBehaviour
{
    //private bool isFirstTimeSceneLoaded = true;

    [SerializeField]
    private Grid grid;

    private Dictionary<string, GridPropertyDetails> gridPropertyDictionary;
    [SerializeField] private SO_GridProperties[] so_gridPropertiesArray = null;

    private void Start()
    {
        InitialiseGridProperties();
    }

    private void InitialiseGridProperties()
    {
        foreach (SO_GridProperties sO_GridProperties in so_gridPropertiesArray)
        {
            Dictionary<string, GridPropertyDetails> gridPropDictionary = new Dictionary<string, GridPropertyDetails>();
            foreach (GridProperty gridProperty in sO_GridProperties.gridPropertyList)
            {
                GridPropertyDetails gridPropertyDetails;

                gridPropertyDetails = GetGridPropertyDetails(gridProperty.gridCoordinate.x,
                    gridProperty.gridCoordinate.y, gridPropertyDictionary);

                if (gridPropertyDetails == null)
                {
                    gridPropertyDetails = new GridPropertyDetails();
                }

                switch (gridProperty.gridBoolProperty)
                {
                    case GridBoolProperty.canPlaceFurniture:
                        gridPropertyDetails.canPlaceFurniture = gridProperty.gridBoolValue;
                        break;

                    case GridBoolProperty.isPath:
                        gridPropertyDetails.isPath = gridProperty.gridBoolValue;
                        break;

                    case GridBoolProperty.isNPCObstacle:
                        gridPropertyDetails.isNPCObstacle = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.canSpawnMonsters:
                        gridPropertyDetails.canSpawnMonsters = gridProperty.gridBoolValue;
                        break;
                }
                SetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDetails, gridPropertyDictionary);
            }
            // If starting scene set the gridPropertyDictionary member variable to the current iteration
            if (sO_GridProperties.sceneName.ToString() == SceneControllerManager.Instance.startingSceneName.ToString())
            {
#pragma warning disable CS1717 // Assignment made to same variable
                this.gridPropertyDictionary = gridPropertyDictionary;
#pragma warning restore CS1717 // Assignment made to same variable
            }
        }
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += AfterSceneLoaded;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= AfterSceneLoaded;
    }

    private void AfterSceneLoaded()
    {
        grid = FindObjectOfType<Grid>();
    }

    /// <summary>
    /// Returns the gridPropertyDetails at the gridlocation for the supplied dictionary, or null if no properties exist at that location.
    /// </summary>
    public GridPropertyDetails GetGridPropertyDetails(int gridX, int gridY, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        // Construct key from coordinate
        string key = "x" + gridX + "y" + gridY;

        GridPropertyDetails gridPropertyDetails;

        // Check if grid property details exist forcoordinate and retrieve
        if (!gridPropertyDictionary.TryGetValue(key, out gridPropertyDetails))
        {
            // if not found
            return null;
        }
        else
        {
            return gridPropertyDetails;
        }
    }

    /// <summary>
    /// Get the grid property details for the tile at (gridX,gridY).  If no grid property details exist null is returned and can assume that all grid property details values are null or false
    /// </summary>
    public GridPropertyDetails GetGridPropertyDetails(int gridX, int gridY)
    {
        return GetGridPropertyDetails(gridX, gridY, gridPropertyDictionary);
    }

    /// <summary>
    /// Set the grid property details to gridPropertyDetails for the tile at (gridX,gridY) for current scene
    /// </summary>
    public void SetGridPropertyDetails(int gridX, int gridY, GridPropertyDetails gridPropertyDetails)
    {
        SetGridPropertyDetails(gridX, gridY, gridPropertyDetails, gridPropertyDictionary);
    }

    /// <summary>
    /// Set the grid property details to gridPropertyDetails for the tile at (gridX,gridY) for the gridpropertyDictionary.
    /// </summary>
    public void SetGridPropertyDetails(int gridX, int gridY, GridPropertyDetails gridPropertyDetails, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        // Construct key from coordinate
        string key = "x" + gridX + "y" + gridY;

        gridPropertyDetails.gridX = gridX;
        gridPropertyDetails.gridY = gridY;

        // Set value
        gridPropertyDictionary[key] = gridPropertyDetails;
    }

}
