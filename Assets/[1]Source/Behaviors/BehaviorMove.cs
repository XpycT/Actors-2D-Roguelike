using System.Collections;
using DG.Tweening;
using Homebrew;
using UnityEngine;

public class BehaviorMove : Behavior, ITick
{
    [Bind] private DataMove dataMove;

    [Bind(From.Object)] private Rigidbody2D rigid;

    [Bind(From.Object)] private BoxCollider2D collider;

    [Bind(From.Object)] private Transform transform;

    
    public override void OnTick()
    {
        if (!Toolbox.Get<DataRoguelikeGameSession>().enabled) return;

        if (!Toolbox.Get<DataRoguelikeGameSession>().playersTurn) return;

        if (dataMove.x != 0 || dataMove.y != 0)
        {
            AttemptMove();
        }
    }

    private void AttemptMove()
    {
        ProcessingSignals.Default.Send(new SignalChangeScore {score = -1});

        if (CanMove())
        {
            Move();
            Toolbox.Get<FactorySounds>().Spawn(Tag.SoundMove);
        }
        
        
        Toolbox.Get<DataRoguelikeGameSession>().playersTurn = false;
    }

    private bool CanMove()
    {
        Vector3 end = transform.position + new Vector3(dataMove.x, dataMove.y);

        collider.enabled = false;

        var hit = Physics2D.Linecast(transform.position, end);

        collider.enabled = true;

        if (hit.transform == null)
        {
            return true;
        }
        if (hit.HasTag(Tag.ColliderHit))
        {
            ProcessingSignals.Default.Send(new SignalTriggerEnter {other = hit.collider});
        }

        if (!hit.HasTag(Tag.ColliderWall)) return true;


        return false;
    }

    private void Move()
    {
        Vector3 end = transform.position + new Vector3(dataMove.x, dataMove.y);
        rigid.DOMove(end, dataMove.moveTime);
    }
}