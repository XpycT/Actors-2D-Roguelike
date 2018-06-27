using Homebrew;

public static class Tag
{
    [TagField(categoryName = "Colliders")] public const int ColliderWall = 0;
    [TagField(categoryName = "Colliders")] public const int ColliderHit = 1;
    [TagField(categoryName = "Colliders")] public const int ColliderInteract = 2;
    
    [TagField(categoryName = "Groups")] public const int GroupEnemies = 100;
    [TagField(categoryName = "Groups")] public const int GroupPlayers = 101;
    [TagField(categoryName = "Groups")] public const int GroupExit = 102;
    [TagField(categoryName = "Groups")] public const int GroupFood = 103;
}