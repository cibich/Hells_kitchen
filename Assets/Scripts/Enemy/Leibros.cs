using System.Collections;
using UnityEngine;

public class Leibros : Enemy
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int _projectileCount = 8;
    [SerializeField] private float _projectileSpeed = 6;
    [SerializeField] private float _projectileDelay = 0.1f;

    public override void Start()
    {
        base.Start();
        StartCoroutine(ShootProjectiles());
    }

    public override void Update()
    {
        base.Update();
        PatrolRoom();
    }

    private IEnumerator ShootProjectiles()
    {
        float angleStep = 360f / _projectileCount;
        while (true)
        {
            for (int i = 0; i < _projectileCount; i++)
            {
                if (DetectionPlayer())
                {
                    float angle = i * angleStep;
                    Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;
                    Vector3 spawnPosition = transform.position + direction;

                    GameObject projectile = Instantiate(_projectilePrefab, spawnPosition, Quaternion.identity);

                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    rb.velocity = direction * _projectileSpeed;
                }
                yield return new WaitForSeconds(_projectileDelay);
            }
        }
    }
}
