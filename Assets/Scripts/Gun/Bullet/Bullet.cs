using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _lifetimeValue;

    public virtual void Start()
    {
        Destroy(gameObject,_lifetimeValue);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponentInChildren<Enemy>().TakeDamage(_damage);
        }
    }
}
