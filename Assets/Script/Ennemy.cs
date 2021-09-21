using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int maxHealt = 100;
    public Animator animator;
    private int currentHealt;
    public HealtBar healtBar;
    public bool isDead = false;
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
        isDead = true;
        animator.SetBool("isDead",true);
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        StartCoroutine(Timer());
    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
