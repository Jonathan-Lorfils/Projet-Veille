using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryScript : MonoBehaviour
{   private float nextParryTime = 0f;
    private bool isParryable = false;
    private float attackRate = 2f;
    [SerializeField] private Animator animator;
    
    // Jumeler avec le script de combat script
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextParryTime)
        {
            if (Input.GetKeyDown("e"))
            {
                isParryable = true;
                StartCoroutine(TimerParry());
                animator.SetTrigger("isParrying");
                nextParryTime = Time.time + 1f / attackRate;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy") && isParryable) // permet de ne pas prendre de degat lorsque l'on parry
        {
            //Script pour que le joueur ne prend aucun degat
            // idee: faire une variable dans take damage, si isParryied est true, le joueur ne prend aucun degats sinon il prend les degats
        } 
        if (other.gameObject.tag.Equals("Bullet") && isParryable) // permet de ne pas prendre de degats des gouttes d'acide lorsque l'on parry
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator TimerParry()
    {
        yield return new WaitForSeconds(0.5f);
        isParryable = false;
    }
}
