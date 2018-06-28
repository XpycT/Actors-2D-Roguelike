using Homebrew;
using DG.Tweening;
using UnityEngine;

public class BehaviorAI : Behavior, IReceive<SignalDamage>, IReceive<SignalMove>
{
    [Bind] private DataMove dataMove;
    [Bind] private DataDamage dataDamage;

    [Bind(From.Object)] private Rigidbody2D rigid;

    [Bind(From.Object)] private BoxCollider2D collider;

    [Bind(From.Object)] private Transform transform;

    [Bind(From.Object)] private Animator anim;

    private Transform target;
    private bool skipMove;

    protected override void Setup()
    {
        target = GameObject.FindObjectOfType<ActorPlayer>().transform;
    }

    private void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;

        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {
            yDir = target.position.y > transform.position.y ? 1 : -1;
        }
        else
        {
            xDir = target.position.x > transform.position.x ? 1 : -1;
        }

        dataMove.x = xDir;
        dataMove.y = yDir;
        AttemptMove();
    }

    private void AttemptMove()
    {
        if (skipMove)
        {
            skipMove = false;
            return;
        }

        if (CanMove())
        {
            Move();
        }

        skipMove = true;
    }

    private void Move()
    {
        Vector3 end = transform.position + new Vector3(dataMove.x, dataMove.y);
        rigid.DOMove(end, dataMove.moveTime);
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

        if (hit.HasTag(Tag.GroupPlayers))
        {
            actor.SignalDispatch(new SignalDamage
            {
                damage = dataDamage.damage, 
                other = hit.transform
            });
            return false;
        }

        if (!hit.HasTag(Tag.ColliderWall) && !hit.HasTag(Tag.GroupEnemies)) return true;


        return false;
    }

    public void HandleSignal(SignalDamage arg)
    {
        ProcessingSignals.Default.Send(new SignalChangeScore
        {
            score = -dataDamage.damage,
            text = "-" + dataDamage.damage
        });
        anim.SetTrigger("enemyAttack");
        arg.other.GetComponent<Animator>().SetTrigger("playerHit");
        
        Toolbox.Get<FactorySounds>().Spawn(Tag.SoundAttack, 0.6f);
    }

    public void HandleSignal(SignalMove arg)
    {
        MoveEnemy();
    }
}