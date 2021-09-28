using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    private bool isDead;

    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private ParryScript _parryScript;

    [SerializeField] private DetectCollisions _detectCollisions;

    [SerializeField] private PlayerDamage _playerDamage;

    [SerializeField] private CombatScript _combatScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isDead = GetComponent<PlayerDamage>().isDead;
        if (isDead)
        {
            _playerMovement.enabled = false;
            _parryScript.enabled = false;
            _detectCollisions.enabled = false;
            _playerDamage.enabled = false;
            _combatScript.enabled = false;
            enabled = false;
        }
    }
}
