using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    private bool isDead;
    
    void Update()
    {
        isDead = GetComponent<PlayerDamage>().isDead;
        if (isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
