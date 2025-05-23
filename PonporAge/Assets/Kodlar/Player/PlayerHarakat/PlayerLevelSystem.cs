using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelSystem : MonoBehaviour
{

    [SerializeField] PlayerStats playerStats;

    [SerializeField] public int leve;
    [SerializeField] public float Soul;
    [SerializeField] public float MaxXp;
    // [SerializeField] Slider XpSlider;
    [SerializeField] public TextMeshProUGUI Soul_text;


    void Update()
    {
        findSouls();
        LevelUp();
        Soul_text.text = Soul.ToString();
        
    }

    public void LevelUp()
    {
        // XpSlider.value = Xp;
        // if (Xp >= MaxXp)
        // {
        //     leve += 1;
        //     MaxXp += MaxXp * 0.2f;
        //     // XpSlider.maxValue = MaxXp;
        //     Xp = 0;

        // }
    }

    public void findSouls()
    {
        Collider2D[] souls = Physics2D.OverlapCircleAll(transform.position, 3f)
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
            Soul += soul.soulXp;
            soul.destory();
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

}
