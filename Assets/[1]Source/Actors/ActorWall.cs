using Homebrew;
using UnityEngine;

public class ActorWall : Actor
{
    [FoldoutGroup("Setup")] public Sprite dmgSprite;
    [FoldoutGroup("Setup")] public DataHP dataHp;

    protected override void Setup()
    {
        Add(dataHp);
        
        Add<BehaviorDamagable>();
        
        tags.Add(Tag.ColliderWall);
    }
}