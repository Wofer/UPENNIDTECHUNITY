using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyScript : MonoBehaviour
{
    public float maxHealth = 20;
    public float health;

    public bool testButton;

    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (testButton) {
            testButton = false;
            dealDamage(5);
        }

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void dealDamage(float damage)
    {
        health -= damage;
    }
}
