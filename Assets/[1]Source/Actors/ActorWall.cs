using Homebrew;
using UnityEngine;

public class ActorWall : Actor
{
    [FoldoutGroup("Setup", true)]
    public Sprite dmgSprite;
    public int hp = 3;

    protected override void Setup()
    {
        Add(dmgSprite);
        Add(hp);
    }

    public void DamageWall()
    {
        Get<SpriteRenderer>().sprite = dmgSprite;
        hp--;
        if (hp <= 0) this.HandleDestroyGO();
    }
}