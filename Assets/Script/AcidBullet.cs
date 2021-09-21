using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D startpoint;
    void Start()
    {
        startpoint.velocity = transform.right * speed;
    }
}
