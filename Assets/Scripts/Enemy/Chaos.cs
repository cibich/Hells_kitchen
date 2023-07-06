using UnityEngine;

public class Chaos : Enemy
{
    [SerializeField] private GameObject _spell;
    [SerializeField] private float _speedSpell;
    [SerializeField] private Transform[] _shotPoint;

    public override void Start()
    {
        base.Start();
        InvokeRepeating("AtackFraction", 0f, 0.5f);
    }

    public override void Update()
    {
        base.Update();
        MoveToPlayer();
    }

    private void AtackFraction()
    {
        if (DetectionPlayer())
        {
            for (int i = 0; i < _shotPoint.Length; i++)
            {
                Vector2 dir = (Vector2)_shotPoint[i].position - (Vector2)transform.position;
                GameObject fireball = Instantiate(_spell, _shotPoint[i].position, Quaternion.identity);
                Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();
                fireballRb.velocity = dir * _speedSpell;
            }
        }
    }
}
