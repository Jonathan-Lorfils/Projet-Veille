using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private int hearts = 6;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hearts <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag.Equals("Bullet"))
        {
            TakeDamage(1);
        }

        if (other.gameObject.tag.Equals("Ennemy"))
        {
            TakeDamage(2);
        }
    }

    void TakeDamage(int damage)
    {
        hearts -= damage;
        animator.SetTrigger("isHurt");
        // velocity en direction oppose (repouser le joueur vers l'arriere)
    }

    void Die()
    {
        
    }
}
