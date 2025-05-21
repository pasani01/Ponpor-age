using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour
{

    [SerializeField] PlayerStats playerStats;

    void Update()
    {
        findSouls();
    }

    public void findSouls()
    {
        Collider2D[] souls = Physics2D.OverlapCircleAll(transform.position, 10f)
            .Where(obj => obj.gameObject.CompareTag("Soul"))
            .ToArray();

        foreach (var item in souls)
        {
            item.gameObject.GetComponent<Soul>().Player = gameObject;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Soul>(out Soul soul))
        {
            soul.destory();
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }

}
