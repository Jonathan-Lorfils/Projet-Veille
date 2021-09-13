using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public bool status; // False = touche au sol et True = dans les airs
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ColliderSol")
        {
            status = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ColliderSol")
        {
            status = true;
        }
    }
}
