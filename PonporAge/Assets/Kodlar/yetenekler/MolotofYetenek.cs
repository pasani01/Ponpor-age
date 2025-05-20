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
        if (other.gameObject.CompareTag("Enamy"))
        {
            
        }
    }
}
