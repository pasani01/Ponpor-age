using System.Threading;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    [SerializeField] EnemyHealthAndTakedamage enemyHealthAndTakedamage;
    [SerializeField] public float EffectTime;
    [SerializeField] public bool isEffect;
    [SerializeField] public float damage;
    [SerializeField] float EffectDamageC = 1;
    [SerializeField] public bool inEffectRange;

    void Start()
    {
        enemyHealthAndTakedamage = GetComponent<EnemyHealthAndTakedamage>();
        
    }
    void Update()
    {

        if (isEffect)
        {
            var e = EffectTime;
            EffectTime -= Time.deltaTime;
            EffectDamageC -= Time.deltaTime;
            if (EffectDamageC <= 0)
            {
                enemyHealthAndTakedamage.TakeFireDamage(damage);
                EffectDamageC = 1;
            }
            if (EffectTime <= 0)
            {
                isEffect = false;
            }
            
            if (inEffectRange)
            {
                EffectTime = e;
            }
        }
        
    }
}
