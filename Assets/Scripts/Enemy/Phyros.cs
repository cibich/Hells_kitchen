using UnityEngine;

public class Phyros : Enemy
{
    [SerializeField] private GameObject _spell;
    [SerializeField] private float _speedSpell;
    [SerializeField] private Transform[] _shotPoint;

    public override void Start()
    {
        base.Start();
        InvokeRepeating("AtackFraction", 0f, 1f);
    }

    public override void Update()
    {
        base.Update();
        PatrolRoom();
    }

    private void AtackFraction()
    {
        if (DetectionPlayer())
        {
            for (int i = 0; i < _shotPoint.Length; i++)
            {
                Vector2 dir = new Vector2(_playerPos.x + Random.Range(-2f, 2f), _playerPos.y + Random.Range(-2f, 2f)) - (Vector2)_shotPoint[i].position;
                GameObject fireball = Instantiate(_spell, _shotPoint[i].position, Quaternion.identity);
                Rigidbody2D fireballRb= fireball.GetComponent<Rigidbody2D>();
                fireballRb.velocity =dir.normalized * Random.Range(6,10);
            }
        }
    }

}
