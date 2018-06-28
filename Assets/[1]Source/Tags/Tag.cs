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
    [TagField(categoryName = "Groups")] public const int GroupSoda = 104;
    
    [TagField(categoryName = "Sounds")] public const int SoundMove = 200;
    [TagField(categoryName = "Sounds")] public const int SoundEat = 201;
    [TagField(categoryName = "Sounds")] public const int SoundDrink = 202;
    [TagField(categoryName = "Sounds")] public const int SoundGameOver = 203;
    [TagField(categoryName = "Sounds")] public const int SoundChops = 204;
    [TagField(categoryName = "Sounds")] public const int SoundAttack = 205;
}