using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class BAutoGun : MonoBehaviour
{
    [SerializeField] private PlayerAction inputActions;
    [SerializeField] private bool ispressed;

    [SerializeField] private float firecooldown;

    [SerializeField] private float _timer;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    [Header("animations")]
    [SerializeField] private Animator animator;
   void Awake()
   {
         inputActions = new PlayerAction();
   }

    void Start()
    {
        inputActions.Gun.fire.performed += Shoot_pressed;
        inputActions.Gun.fire.canceled += Shoot_released;

    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (ispressed)
        {   
            if (_timer >= firecooldown)
            {
                Fire();
                _timer = 0;
            }
            
        }
    }

    private void Fire()
    {
        animator.SetTrigger("screen");
        GameObject _bullet=Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = _bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletSpawnPoint.up * 20, ForceMode2D.Impulse);
        Destroy(_bullet, 3f);
  
    }

    private void Shoot_pressed(InputAction.CallbackContext context)
    {
        ispressed = true;
    }

    private void Shoot_released(InputAction.CallbackContext context)
    {
        ispressed = false;
    }

    void OnEnable()
   {
        inputActions.Enable();
   }
    void OnDisable()
    {
          inputActions.Disable();
    }
}
