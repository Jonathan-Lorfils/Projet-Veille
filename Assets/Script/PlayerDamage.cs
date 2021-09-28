using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private int hearts = 10;
    public bool isDead = false;
    public Animator animator;

    [SerializeField] private ParryScript _parryScript;

    private bool isParryable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isParryable = _parryScript.isParryable;
        if (hearts <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag.Equals("Bullet") && !isParryable)
        {
            Destroy(other.gameObject);
            TakeDamage(1);
        }

        if (other.gameObject.tag.Equals("Ennemy") && !isParryable)
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
        isDead = true;
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
