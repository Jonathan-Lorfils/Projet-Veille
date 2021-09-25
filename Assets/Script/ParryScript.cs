using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryScript : MonoBehaviour
{
    [SerializeField] CircleCollider2D _circleCollider2D;

    private bool isTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isTrigger)
        {
            Debug.Log("Parry");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Bullet"))
        {
            Debug.Log("Rentre");
            isTrigger = true;
        } 
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Bullet"))
        {
            Debug.Log("Sort");
            isTrigger = false;
        } 
    }

/*    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKey("e"))
        {
            Debug.Log("E");
           if (other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Bullet") )
           {
               Debug.Log("toucher");
           } 
        }
    }
    */
}
