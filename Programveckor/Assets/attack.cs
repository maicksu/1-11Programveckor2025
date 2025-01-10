using UnityEngine;

public class SquareAttack2D : MonoBehaviour
{
    public float attackRange = 1.5f; // Range of the attack
    public int attackDamage = 10;   // Damage dealt to enemies
    public LayerMask enemyLayer;    // Layer to identify enemies

    void Update()
    {
        // Trigger attack when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Detect all enemies within range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        // Damage each enemy detected
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            EnemyHealth2D enemyHealth = enemy.GetComponent<EnemyHealth2D>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw the attack range in the Scene view for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
