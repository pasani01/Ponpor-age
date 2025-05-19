using System;
using System.Collections;
using UnityEngine;

public class PlayerHarakat : MonoBehaviour
{   
    [SerializeField] private PlayerAction playerAction;
    [SerializeField] public float playerSpeed;

    [SerializeField] private float newSpeed;
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
        if(PlayerStats.instance!= null)
        {
            PlayerStats.instance.OnChangeValue += UpdateStats;
        }
        else
        {
            Debug.Log("PlayerStats instance not found");
        }
        
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void UpdateStats(float value)
    {
        newSpeed = playerSpeed;
        newSpeed += playerSpeed * (value / 100);

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
        rb.MovePosition(rb.position +  playerDirection*newSpeed * Time.fixedDeltaTime);
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
