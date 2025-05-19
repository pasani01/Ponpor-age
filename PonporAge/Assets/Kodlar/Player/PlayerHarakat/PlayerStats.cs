using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance { get; private set; }

    [SerializeField] public float _playerspeed;
    public float playerspeed
    {
        get => _playerspeed;
        set
        {
            if (Math.Abs(_playerspeed - value) > 0.001f)
            {
                _playerspeed = value;
                Debug.Log("valur" + value);
                OnChangeValue?.Invoke(value);
                Debug.Log(OnChangeValue);
            }

        }

    }
    [SerializeField] public float _playerMaxhealth;
    public float playerMaxhealth
    {
        get => _playerMaxhealth;
        set
        {
            _playerMaxhealth = value;
            OnChangeValue?.Invoke(_playerMaxhealth);
        }
    }
    [Header("player damages")]
    [SerializeField] public float _player_magicDamage;
    public float player_magicDamage
    {
        get => _player_magicDamage;
        set
        {
            _player_magicDamage = value;
            OnChangeValue?.Invoke(player_magicDamage);
        }
    }
    [SerializeField] public float _player_physicalDamage;
    public float player_physicalDamage
    {
        get => _player_physicalDamage;
        set
        {
            _player_physicalDamage = value;
            OnChangeValue?.Invoke(player_physicalDamage);
        }
    }
    [SerializeField] public float _player_gunDamage;
    public float player_gunDamage
    {
        get => _player_gunDamage;
        set
        {
            _player_gunDamage = value;
            OnChangeValue?.Invoke(player_gunDamage);
        }
    }
    [SerializeField] public float _player_explosionDamage;
    public float player_explosionDamage
    {
        get => _player_explosionDamage;
        set
        {
            _player_explosionDamage = value;
            OnChangeValue?.Invoke(player_explosionDamage);
        }
    }

    [Header("player defence")]
    [SerializeField] public float _player_magicDefence;
    public float player_magicDefence
    {
        get => _player_magicDefence;
        set
        {
            _player_magicDefence = value;
            OnChangeValue?.Invoke(player_magicDefence);
        }
    }
    [SerializeField] public float _player_physicalDefence;
    public float player_physicalDefence
    {
        get => _player_physicalDefence;
        set
        {
            _player_physicalDefence = value;
            OnChangeValue?.Invoke(player_physicalDefence);
        }
    }
    [SerializeField] public float _player_Defence;
    public float player_Defence
    {
        get => _player_Defence;
        set
        {
            _player_Defence = value;
            OnChangeValue?.Invoke(player_Defence);
        }
    }


    [Header("player attack speed")]
    [SerializeField] public float _player_attackSpeed;
    public float player_attackSpeed
    {
        get => _player_attackSpeed;
        set
        {
            _player_attackSpeed = value;
            OnChangeValue?.Invoke(player_attackSpeed);
        }
    }

    [Header("player attack range")]
    [SerializeField] public float _player_attackRange;
    public float player_attackRange
    {
        get => _player_attackRange;
        set
        {
            _player_attackRange = value;
            OnChangeValue?.Invoke(player_attackRange);
        }
    }

    [Header("Events")]
    [SerializeField]
    public Action<float> OnChangeValue;






    void Awake()
    {

        instance = this;


    }
    
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerspeed += 1;
        }
     
    }
    
}
