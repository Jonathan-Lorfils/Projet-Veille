using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask ennemyLayers;
    public int attackDamageBasic = 20;
    public int attackDamageCharged = 40;
    public float attackRate = 2f;
    private float nextAttackTimeBasic = 0f;
    private float nextAttackTimeCharged = 0f;
    void Update()
    {
        if (Time.time >= nextAttackTimeBasic)
        {
           if (Input.GetMouseButtonDown(0))// clique gauche
           {
               Attack("basic");
               nextAttackTimeBasic = Time.time + 1f / attackRate;
           }
        }

        if (Time.time >= nextAttackTimeCharged)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Attack("charged");
                nextAttackTimeCharged = Time.time + 2f / attackRate;
            }
        }
    }

    void Attack(String typeAttaque)
    {
        // Detecter les ennemies dans le range d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,ennemyLayers);
        if (typeAttaque == "basic")
        {
            animator.SetTrigger("isAttackingBasic");
            // appliquer des degats
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Ennemy>().TakeDamage(attackDamageBasic);
            }
        }
        if (typeAttaque == "charged")
        {
            animator.SetTrigger("isAttackingCharged");
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Ennemy>().TakeDamage(attackDamageCharged);
            }
        }
    }
}
