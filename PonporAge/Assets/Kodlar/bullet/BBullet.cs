using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<BEnemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
