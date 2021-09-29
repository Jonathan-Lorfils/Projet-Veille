using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollowSkeleton : MonoBehaviour
{
    // matcher avec le script ennemy *possible fusion avec le scrip ennemy*
    // Peut etre le faire arreter de chase lorsque le joueur est trop loin
    public float speed;

    private Transform target;
    public float radiusDetection = 5;
    private bool isChasing = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si l'ennemie est mort le script se desactive
        if (gameObject.GetComponent<Ennemy>().isDead)
        {
            enabled = false;
        }
        
        if (isChasing)
        {
            if (Vector2.Distance(transform.position, target.position) > 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                Attack();
            }
        }

        if (Vector3.Distance(gameObject.transform.position,target.transform.position ) <= radiusDetection && !isChasing)
        {
            isChasing = true;
            animator.SetBool("isChasing",true);
        }
        
        // Permet de faire changer de direction l'ennemie selon sa target
        Quaternion rotation = transform.rotation;
        if (target.position.x > gameObject.transform.position.x)
        {
            rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            rotation = new Quaternion(0, 180, 0, 0);
        }
        
        transform.rotation = rotation;
    }
    
    void Attack()
    {
        if (!GetComponent<Ennemy>().isDead)
        {
            animator.SetTrigger("Attack");
        }
    }
}
