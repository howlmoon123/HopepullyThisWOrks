public enum SceneName
{
    Scene1_Farm,
    Scene2_Cabin,
    Scene3_Town,
    Scene4_Wilderness,
    Scene5_Cave,
    Scene6_Dungeon,
    Scene7_BattleScene,
    Armor_Scene,
    Magic_Scene,
    GeneralStore_Scene

}

public enum Direction
{
    up,
    down,
    left,
    right
}

public enum GridBoolProperty
{
   PlayerMovementHinderance,
   none,
   count
}

public enum TileHinderanceType
{
    Water,
    Mountain,
    Forrest,
    Swamp,
    Desert,
    none,
    count
}

public enum InventoryItemType
{
    Weapon,
    Magic,
    Clerical,
    Consumable,
    none,
    count
}

public enum InventoryLocations
{
    Player,
    Armorer,
    Magic_Shop,
    General_Store,
    none,
    count
}