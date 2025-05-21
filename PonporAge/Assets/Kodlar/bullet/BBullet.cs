using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<EnemyHealthAndTakedamage>(out EnemyHealthAndTakedamage enemyTakeDamage))
            {
                enemyTakeDamage.TakeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}
