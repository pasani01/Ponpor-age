using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    [SerializeField] private float speed = 5f;

    void Update()
    {
        if (Player != null)
        {
            Vector3 direction = (Player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
