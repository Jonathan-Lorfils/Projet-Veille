using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollow : MonoBehaviour
{
    // matcher avec le script ennemy *possible fusion avec le scrip ennemy*
    public float speed;

    public Transform target;
    public float radiusDetection = 5;
    public bool isChasing = false;
    public Animator animator;
    public Transform firePoint;
    public GameObject acidBulletPrefab;
    private bool coroutineStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Ennemy>().isDead)
        {
            this.enabled = false;
        }

        if (Vector2.Distance(transform.position, target.position) > 0 && isChasing)
        {
           transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            // attaquer le joueur
        }

        if (Vector3.Distance(gameObject.transform.position,target.transform.position ) <= radiusDetection && !GetComponent<Ennemy>().isDead)
        {
            isChasing = true;
            animator.SetBool("isChasing",true);
        }

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

        if (isChasing && !coroutineStarted)
        {
            StartCoroutine(Timer());
            coroutineStarted = true;
        }
    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        Attack();
    }

    void Attack()
    {
        animator.SetBool("Attack",true);
        Instantiate(acidBulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("Attack",false);
        coroutineStarted = false;
    }
}
