using System.Threading;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHealthAndTakedamage : MonoBehaviour
{
    [Header("Enamy health")]
    [SerializeField] public float enemyMaxHealth;
    [SerializeField] public float enemyHealth;

    [Header("Enamy Defans")]
    [SerializeField] public float enemyDefans;
    [SerializeField] public float enemyFireDefans;
    [SerializeField] public float enemyMagicDafans;
    [SerializeField] public float enemyExplotionDefans;

    [SerializeField] private float tiemr;


    [Header("Enemy Effacts")]
    [SerializeField] public bool enemyFireEffect;

    [Header("Materyals")]
    [SerializeField] private  Material []enemyMaterial;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        // ------------------------------------//
        enemyHealth = enemyMaxHealth;
        enemyDefans = math.clamp(enemyDefans, -80, 70);
        enemyFireDefans = math.clamp(enemyDefans, -80, 70);
        enemyExplotionDefans = math.clamp(enemyDefans, -80, 70);
        enemyMagicDafans = math.clamp(enemyDefans, -80, 70);
        
    }

    public IEnumerator ChangeColor()
    {
        spriteRenderer.material = enemyMaterial[1];
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material = enemyMaterial[0];
    }


    public void TakeFireDamage(float damage)
    {
        var d = damage;
        d -= damage * (enemyFireDefans / 100);
        TakeDamage(d);

    }
    public void TakeMegicDamage(float damage)
    {
        var d = damage;
        d -= damage * (enemyMagicDafans / 100);
        TakeDamage(d);
    }

    public void TakeExplotionDamage(float damage)
    {
        var d = damage;
        d -= damage * (enemyExplotionDefans / 100);
        TakeDamage(d);
    }

    public void TakeDamage(float damage)
    {
        var d = damage;
        d -= damage * (enemyDefans / 100);
        enemyHealth -= d;
        enemyHealth = Mathf.Clamp(enemyHealth, 0, enemyMaxHealth);
        StartCoroutine(ChangeColor());
        
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        Destroy(gameObject);
    }
}
