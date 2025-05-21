using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour
{

    [SerializeField] PlayerStats playerStats;



    public void findSouls()
    {
        Collider2D[] souls = Physics2D.OverlapCircleAll(transform.position, 10f)
            .Where(obj => obj.gameObject.GetComponent<Soul>() != null)
            .ToArray();

        foreach (var item in souls)
        {
            item.gameObject.GetComponent<Soul>().Player = this.gameObject;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Soul>())
        {
            Destroy(other.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }

}
