using System.Collections;
using UnityEngine;

public class Hunter : Enemy
{
    [SerializeField] private SpriteRenderer _hunterSpriteRenderer;
    [SerializeField] private float _speedSpeel;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shotPoint;
    
    public override void Start()
    {
        base.Start();
        StartCoroutine(Shield());
    }

    public override void Update()
    {
        base.Update();
        PatrolRoom();
    }

    private void Atack()
    {
        if (DetectionPlayer())
        {
            Vector2 dir = _playerPos - (Vector2)_shotPoint.position;
            GameObject spell = Instantiate(_bullet, _shotPoint.position, Quaternion.identity);
            Rigidbody2D spellRb = spell.GetComponent<Rigidbody2D>();
            spellRb.velocity = dir.normalized * _speedSpeel;
        }
    }

    private IEnumerator Shield()
    {
        while (_health > 0)
        {
            if (DetectionPlayer())
            {
                _hunterSpriteRenderer.enabled = true;
                Atack();
                yield return new WaitForSeconds(3f);
            }

            _hunterSpriteRenderer.enabled=false;
            yield return new WaitForSeconds(2f);
        }
    }
}
