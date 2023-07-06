using UnityEngine;

public class BananBullet : Bullet
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _gravity;
    [SerializeField] private float _rotateSpeed;

    private void FixedUpdate()
    {
        _rb.velocity += Vector2.up * _gravity * Time.fixedDeltaTime;

        if (_rb.velocity.x > 0)
            transform.Rotate(0, 0, _rotateSpeed);
        else if (_rb.velocity.x < 0)
            transform.Rotate(0, 0, Mathf.Abs(_rotateSpeed));
    }
}
