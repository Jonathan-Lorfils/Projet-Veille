using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private int maxHealt = 100;
    private int currentHealt;
    public bool isDead;
    public Animator animator;
    public float ForceParry = 1;
    public HealtBar healtBar;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private ParryScript _parryScript;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector3 direction;
    private bool isParryable;
    private bool isVulnerable;
    // idee: faire flasher le joueurs entre la couleur rouge et blanche quand il est PAS vulnerable
    // Start is called before the first frame update
    void Start()
    {
        isVulnerable = true;
        isDead = false;
        currentHealt = maxHealt;
        healtBar.SetHealt(currentHealt,maxHealt);
    }

    // Update is called once per frame
    void Update()
    {
        isParryable = _parryScript.isParryable;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag.Equals("Bullet"))
        {
            Destroy(other.gameObject);
            
            if (!isParryable && isVulnerable)
            {
                repulseEffect(other.transform.rotation.y);
                isVulnerable = false;
                StartCoroutine(TimerInvincibility());
                TakeDamage(10);
            }
        }
        
        if (other.gameObject.tag.Equals("Sword") && !isParryable && isVulnerable)
        {
            repulseEffect(other.transform.rotation.y);
            TakeDamage(20);
            isVulnerable = false;
            StartCoroutine(TimerInvincibility());
            var force = transform.position - other.transform.position;
            force.Normalize();
            _rigidbody2D.AddForce (-force * ForceParry);
        }

        if (other.gameObject.tag.Equals("NextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.gameObject.tag.Equals("Fall"))
        {
            Die();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealt -= damage;
        healtBar.SetHealt(currentHealt,maxHealt);
        animator.SetTrigger("isHurt");
        if (currentHealt <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetBool("isDead",true);
        StartCoroutine(TimerDeath());
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
    }
    
    IEnumerator TimerDeath()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    
    IEnumerator TimerInvincibility()
    {
        StartCoroutine(Flash());
        yield return new WaitForSeconds(2f);
        isVulnerable = true;
    }
    
    IEnumerator Flash()
    {
        for (int i = 0; i < 10; i++)
        {
            _spriteRenderer.material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            _spriteRenderer.material.color = Color.white; 
            yield return new WaitForSeconds(.1f);
        }
    }

    void repulseEffect(float rotation)
    {
        if (rotation == 0)
        {
            _rigidbody2D.AddForce(new Vector2(5,0),ForceMode2D.Impulse);
        }
        else
        {
            _rigidbody2D.AddForce(new Vector2(-5,0),ForceMode2D.Impulse);
        }
    }
}
