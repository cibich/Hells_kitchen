using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected Vector2 _spawnPos;
    [SerializeField] protected Vector2 _playerPos;
    [SerializeField] protected Vector2 _dirToPatrol;
    [SerializeField] protected int _health;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _detectionPlayer = 19f;
    [SerializeField] protected float _detectionObstacle = 3f;
    [SerializeField] protected GameObject [] _loot;

    public virtual void OnDisable()
    {
        Instantiate(_loot[Random.Range(0, _loot.Length)], transform.position, Quaternion.identity);
    }

    public virtual void Start()
    {
        _spawnPos = transform.position;
        SpawnTurning();
    }

    public virtual void Update()
    { 
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        TurningToMove();
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            EventManager.OnEnemyDied();
            Destroy(gameObject);
        }
    }

    public virtual bool DetectionPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (_playerPos - (Vector2)transform.position).normalized, _detectionPlayer, LayerMask.GetMask("Default", "Player")) ;

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Projectile"))
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public virtual void MoveToPlayer()
    {
        if (DetectionPlayer())
        {
            _rigidbody.velocity =(_playerPos-(Vector2)transform.position).normalized * _moveSpeed;
            TurningToMove();
        }
        else
            _rigidbody.velocity = (_spawnPos - (Vector2)transform.position).normalized * _moveSpeed;
    }

    public virtual void PatrolRoom()
    {
        if (DetectionPlayer())
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, _dirToPatrol.normalized, _detectionObstacle, LayerMask.GetMask("Default", "Obstacle"));

            if (hit.collider != null)
            {
                _dirToPatrol = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * _moveSpeed;
            }

            _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, _dirToPatrol, _moveSpeed * Time.deltaTime);
            TurningToMove();
        }
        else
            _rigidbody.velocity = (_spawnPos - (Vector2)transform.position).normalized * _moveSpeed;
    }

    protected void TurningToMove()
    {
        if (_rigidbody.velocity.x < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else if (_rigidbody.velocity.x > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
    protected void SpawnTurning()
    {
        if (transform.position.x > 0 && transform.localScale.x > 0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else if (transform.position.x < 0 && transform.localScale.x < 0)
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
}
