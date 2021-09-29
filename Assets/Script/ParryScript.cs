using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryScript : MonoBehaviour
{   private float nextParryTime = 0f;
    public bool isParryable = false;
    private float attackRate = 2f;
    [SerializeField] private Animator animator;

    // Jumeler avec le script de combat script
    
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

    IEnumerator TimerParry()
    {
        yield return new WaitForSeconds(0.5f);
        isParryable = false;
    }
}
