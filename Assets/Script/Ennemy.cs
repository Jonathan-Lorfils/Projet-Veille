using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int maxHealt = 100;
    public Animator animator;
    private int currentHealt;
    public HealtBar healtBar;
    void Start()
    {
        currentHealt = maxHealt;
        healtBar.SetHealt(currentHealt,maxHealt);
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;

        animator.SetTrigger("isHurt");
        
        healtBar.SetHealt(currentHealt,maxHealt);

        if (currentHealt <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead",true);

       // healtBar.slider.GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
