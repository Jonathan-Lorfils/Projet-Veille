using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float VitesseMouvement = 3;
    public float ForceSaut = 8;
    public Collider2D CollisionSol;

    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        var mouvement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(mouvement, 0, 0) * Time.deltaTime * VitesseMouvement;

        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(new Vector2(0,ForceSaut),ForceMode2D.Impulse);
        }
    }
}
