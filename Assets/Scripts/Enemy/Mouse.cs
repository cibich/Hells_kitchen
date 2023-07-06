using UnityEngine;

public class Mouse : Enemy
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Vector2 _direction;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        MoveToPlayer();

        if ((Vector2)transform.position == _spawnPos)
            _anim.SetBool("IsRun", false);
        else _anim.SetBool("IsRun", true);
    }
}

