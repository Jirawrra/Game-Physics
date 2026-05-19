using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;


    void OnCollisionEnter(Collision collision)
    {
        // Check if hit by bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;

            Debug.Log("Enemy hit! Health: " + health);

            // Destroy bullet
            Destroy(collision.gameObject);

            // Enemy dies
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        Animator animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.enabled = false;
        }

        Destroy(gameObject, 2f);
    }
}