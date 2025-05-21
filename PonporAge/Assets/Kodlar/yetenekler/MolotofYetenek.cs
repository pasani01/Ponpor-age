using UnityEngine;

public class MolotofYetenek : MonoBehaviour
{
    [SerializeField] public float Radios;
    [SerializeField] public float lifeTime;
    [SerializeField] public float damage;

    [SerializeField] private float damageCoolDaown;
    [SerializeField] float timer;


    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<FireEffect>(out FireEffect effect))
            {

                effect.inEffectRange = true;
                effect.isEffect = true;
                effect.damage = damage;
                effect.EffectTime = 3f;


            }
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<FireEffect>(out FireEffect effect))
            {
                effect.inEffectRange = false;

            }
        }
    }
}
