using System.Collections;
using UnityEngine;

public class BEnemy : MonoBehaviour
{

    [SerializeField] private Transform playerPos;
    [SerializeField] private float speed;
    [SerializeField] public float enemeyAttackRange;
    [SerializeField] private SpriteRenderer spriteRenderer;


    void Start()
    {
        speed = Random.Range(2f, 4f);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemeyAttackRange);
    }
}
