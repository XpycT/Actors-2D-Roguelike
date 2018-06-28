using System.Collections;
using DG.Tweening;
using Homebrew;
using UnityEngine;

public class BehaviorMove : Behavior, ITick, ITickFixed
{
    [Bind] private DataMove dataMove;

    [Bind(From.Object)] private Rigidbody2D rigid;

    [Bind(From.Object)] private BoxCollider2D collider;

    [Bind(From.Object)] private Transform transform;

    protected override void Setup()
    {
        base.Setup();
    }

    public override void OnTick()
    {
        if (!Toolbox.Get<DataRoguelikeGameSession>().playersTurn) return;

        if (dataMove.x != 0 || dataMove.y != 0)
        {
            AttemptMove();
        }

        Toolbox.Get<DataRoguelikeGameSession>().playersTurn = false;

        Timer.Add(Toolbox.Get<DataRoguelikeGameSession>().turnDelay,
            () => { Toolbox.Get<DataRoguelikeGameSession>().playersTurn = true; });
    }

    private void AttemptMove()
    {
        ProcessingSignals.Default.Send(new SignalChangeScore {score = -1});

        if (CanMove())
        {
            Move();
            Toolbox.Get<FactorySounds>().Spawn(Tag.SoundMove);
        }
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


        Collider2D col = hit.transform.GetComponent<Collider2D>();
        if (!col.HasTag(Tag.ColliderWall)) return true;


        return false;
    }

    private void Move()
    {
        Vector3 end = transform.position + new Vector3(dataMove.x, dataMove.y);
        rigid.DOMove(end, dataMove.moveTime);
    }
}