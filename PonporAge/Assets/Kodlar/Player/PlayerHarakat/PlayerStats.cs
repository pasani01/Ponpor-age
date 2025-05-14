using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float _playerSpeed ;
    [SerializeField] public float _playerMaxhealth ;
    [Header("player damages")]
    [SerializeField] public float _player_magicDamage ;
    [SerializeField] public float _player_physicalDamage ;
    [SerializeField] public float _player_gunDamage ;
    [SerializeField] public float _player_explosionDamage ;
    
    [Header("player defence")]
    [SerializeField] public float _player_magicDefence ;
    [SerializeField] public float _player_physicalDefence ;
    [SerializeField] public float _player_Defence ;


    [Header("player attack speed")]
    [SerializeField] public float _player_attackSpeed ;

    [Header("player attack range")]
    [SerializeField] public float _player_attackRange ;
}
