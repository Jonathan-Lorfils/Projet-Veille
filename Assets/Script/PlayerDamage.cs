using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private int hearts = 1;
    public bool isDead = false;
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

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.tag.Equals("Bullet"))
        {
            Destroy(other.gameObject);
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
        Debug.Log(hearts);
        // velocity en direction oppose (repouser le joueur vers l'arriere)
    }

    void Die()
    {
        animator.SetBool("isDead",true);
        StartCoroutine(Timer());
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
