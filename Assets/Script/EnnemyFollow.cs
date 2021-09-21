using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollow : MonoBehaviour
{
    // matcher avec le script ennemy
    public float speed;

    private Transform target;
    
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

        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            // attaquer le joueur
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
    }
}
