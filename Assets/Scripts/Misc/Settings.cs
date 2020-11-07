
using UnityEngine;

public static class Settings 
{
    // Scenes
    public const string PersistentScene = "PersistentScene";

    // Obscuring Item Fading - ObscuringItemFader
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.45f;

    // Tilemap
    public const float gridCellSize = 1f; // grid cell size in unity units
    public const float gridCellDiagonalSize = 1.41f; // diagonal distance between unity cell centres
    public const int maxGridWidth = 99999;
    public const int maxGridHeight = 99999;
    public static Vector2 cursorSize = Vector2.one;

    // Player
    public static float playerCentreYOffset = 0.875f;


    // Player Movement
    public const float runningSpeed = 5.333f;
    public const float walkingSpeed = 2.666f;
   
    //NPC Movement
    public static float pixelSize = 0.0625f;

    // Inventory
    public static int playerInitialInventoryCapacity = 24;
    public static int playerMaximumInventoryCapacity = 48;

    // NPC Animation Parameters
    public static int walkUp;
    public static int walkDown;
    public static int walkLeft;
    public static int walkRight;
    public static int eventAnimation;

    // Player Animation Parameters
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
  

   
   
   

    // Time System
    public const float secondsPerGameSecond = 0.012f;


    // static constructor
    static Settings()
    {
       
    }
}
