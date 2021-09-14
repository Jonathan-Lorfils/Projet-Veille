using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float VitesseMouvement = 3;
    public float ForceSaut = 8;
    public DetectCollisions CollisionsSol;
    private Rigidbody2D _rigidbody2D;
    public Animator animator;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        var mouvement = Input.GetAxis("Horizontal");
        var hauteur = Input.GetAxis("Vertical");
        transform.position += new Vector3(mouvement, 0, 0) * Time.deltaTime * VitesseMouvement;

        animator.SetFloat("Speed",Mathf.Abs(mouvement));
        
        if (mouvement < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if (mouvement > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (Input.GetButtonDown("Jump") && CollisionsSol.status == false)
        {
            _rigidbody2D.AddForce(new Vector2(0,ForceSaut),ForceMode2D.Impulse);
            animator.SetBool("isJumping",true);
        }
        
        
        
        
        
    }
}
