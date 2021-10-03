using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public void AE_footstep()
    {
        FindObjectOfType<AudioManager>().Play("Walk");
    }
    
    public void AE_Landing()
    {
        FindObjectOfType<AudioManager>().Play("Landing");
    }
    
    public void AE_Hurt()
    {
        FindObjectOfType<AudioManager>().Play("Hurt");
    }
    
    public void AE_SwordAttack()
    {
        FindObjectOfType<AudioManager>().Play("Attack");
    }
    
    public void AE_Parry()
    {
        FindObjectOfType<AudioManager>().Play("Parry");
    }
    
    public void AE_Death()
    {
        FindObjectOfType<AudioManager>().Play("Death");
    }
}
