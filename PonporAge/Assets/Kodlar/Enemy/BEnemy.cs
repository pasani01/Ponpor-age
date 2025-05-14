using System.Collections;
using UnityEngine;

public class BEnemy : MonoBehaviour
{

    [SerializeField] private Transform playerPos;
    [SerializeField] private float speed;
    [SerializeField] public float enemeyAttackRange;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private  Material []enemyMaterial;


    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {   
        if (playerPos == null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else if (Vector2.Distance(transform.position, playerPos.position) > enemeyAttackRange)
        {
            MoveTowardsPlayer();
        }


    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = playerPos.position - transform.position;
        direction.Normalize();
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {   
       StartCoroutine(ChangeColor());
        Debug.Log("Enemy took damage: " + damage);
        
    }

    IEnumerator ChangeColor()
    {
        spriteRenderer.material = enemyMaterial[1];
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material = enemyMaterial[0];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemeyAttackRange);
    }
}
