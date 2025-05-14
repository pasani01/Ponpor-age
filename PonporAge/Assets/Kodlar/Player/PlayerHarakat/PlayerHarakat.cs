using System.Collections;
using UnityEngine;

public class PlayerHarakat : MonoBehaviour
{
    [SerializeField] private PlayerAction playerAction;
    [SerializeField] public float playerSpeed;
    [SerializeField] private Vector2 playerDirection;
    [SerializeField] private float playerDeshSpeed;
    [SerializeField] private float playerDeshTime;
    [SerializeField] private float playerdeshcooldown;
    [SerializeField] private bool isPlayerDesh;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float  timerForDesh;
    float players;
    
    void Awake()
    {
        playerAction =new PlayerAction();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {   

        
        if(!isPlayerDesh)
        {
            playerDirection = playerAction.Player.Harakat.ReadValue<Vector2>();
        }
        
        timerForDesh += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {  
            if (!isPlayerDesh && timerForDesh >= playerdeshcooldown)
            {
                StartCoroutine(PlayerDesh());
                timerForDesh = 0;
            }
           
        }



    }

    IEnumerator PlayerDesh()
    {
        players=playerSpeed;
        playerSpeed = playerDeshSpeed;
        isPlayerDesh = true;
        yield return new WaitForSeconds(playerDeshTime);
        playerSpeed = players;
        
        yield return new WaitForSeconds(0.1f);
        isPlayerDesh = false;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerDirection * playerSpeed * Time.fixedDeltaTime);
    }
    void OnEnable()
    {
        playerAction.Enable();
    }
    void OnDisable()
    {
        playerAction.Disable();
    }


}
