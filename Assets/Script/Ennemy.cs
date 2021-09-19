using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int maxHealt = 100;
    public Animator animator;
    private int currentHealt;
    void Start()
    {
        currentHealt = maxHealt;
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        
        animator.SetTrigger("isHurt");

        if (currentHealt <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead",true);
        
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
