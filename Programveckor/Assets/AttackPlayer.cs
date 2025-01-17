using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public HealthManager playerHealth;
    void AttackPlayer()
    {
        playerHealth.TakeDamage(10f);
    }
}
