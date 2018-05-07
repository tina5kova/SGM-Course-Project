using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    private int health;
    [SerializeField] private Image healthBar;
    public event Action OnDied = delegate { };
    
    public Transform deathPoint;
    public Transform deathPrefab;

    
    void Awake()
    {
        health = maxHealth;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(10);
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = (float)health / maxHealth;
        if (health <= 0)
        {
            Transform spawnParticles = Instantiate(deathPrefab, deathPoint.position, Quaternion.Inverse(deathPoint.rotation)) as Transform;
            Destroy(spawnParticles.gameObject, 10f);
            Die();
        }
    }

    private void Die()
    {
        OnDied();  
        Destroy(gameObject,1f);
       
    }

    


}
