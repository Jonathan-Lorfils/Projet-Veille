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
    public int attackDamage = 40;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
           if (Input.GetMouseButtonDown(0))// clique gauche
           {
               Attack();
               nextAttackTime = Time.time + 1f / attackRate;
           } 
        }
    }

    void Attack()
    {
        // Jouer l'animation d'attaque *ajouter attaque charge, aerienne,*
        animator.SetTrigger("isAttacking");
        // Detecter les ennemies dans le range d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,ennemyLayers);
        // appliquer des degats
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Ennemy>().TakeDamage(attackDamage);
        }
    }
}
