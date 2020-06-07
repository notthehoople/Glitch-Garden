using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] int damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO Add different damage based on the enemy that collides with us
        FindObjectOfType<PlayerHealth>().LoseHealth(damage);

        // BUGFIX: destroy the attacker that reaches us otherwise it's impossible for the player to win!
        FindObjectOfType<LevelController>().AttackerKilled();
        Destroy(gameObject);
    }
}
