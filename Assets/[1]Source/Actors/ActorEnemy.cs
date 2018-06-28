using Homebrew;

public class ActorEnemy : Actor
{
    [FoldoutGroup("Setup")] public DataMove dataMove;
    
    [FoldoutGroup("Setup")] public DataDamage dataDamage;
    
    protected override void Setup()
    {
        Add(dataMove);
        Add(dataDamage);
        
        Add<DataRaycast>();
        Add<BehaviorAI>();
        
        tags.Add(Tag.GroupEnemies);
    }
}