using System.Collections.Generic;
using UnityEngine;

public abstract class Treasure : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _treasureItems;

    public virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F))
        {
            Destroy(gameObject);
            Instantiate(_treasureItems[Random.Range(0,_treasureItems.Count)], new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        }
    }
}
