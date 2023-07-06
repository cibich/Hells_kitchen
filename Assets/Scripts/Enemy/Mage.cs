using System.Collections;
using UnityEngine;

public class Mage : Enemy
{
    [SerializeField] private GameObject _spell;
    [SerializeField] private float _speedSpeel;
    [SerializeField] private Transform[] _shotPoint;

    public override void Start()
    {
        base.Start();
        StartCoroutine(UseSpells());
    }

    public override void Update()
    {
        base.Update();
        MoveToPlayer();
    }

    private void Atack()
    {
        if (DetectionPlayer())
        {
            Vector2 dir = _playerPos - (Vector2)_shotPoint[0].position;
            GameObject spell = Instantiate(_spell, _shotPoint[0].position, Quaternion.identity);
            Rigidbody2D spellRb = spell.GetComponent<Rigidbody2D>();
            spellRb.velocity = dir.normalized * _speedSpeel;
        }
    }

    private void AtackFraction()
    {
        if (DetectionPlayer())
        {
            for (int i = 0; i < _shotPoint.Length; i++)
            {
                Vector2 dir = new Vector2(_playerPos.x+Random.Range(-2f,2f), _playerPos.y + Random.Range(-2f, 2f)) - (Vector2)_shotPoint[i].position;
                GameObject fireball = Instantiate(_spell, _shotPoint[i].position, Quaternion.identity);
                Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();
                fireballRb.velocity = dir.normalized * _speedSpeel;
            }
        }
    }

    private IEnumerator UseSpells()
    {
        while (_health > 0)
        {
            AtackFraction();
            yield return new WaitForSeconds(0.7f);
            Atack();
            yield return new WaitForSeconds(0.7f);
        }
    }
}
