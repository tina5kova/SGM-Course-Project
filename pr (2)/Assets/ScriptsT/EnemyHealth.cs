using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class EnemyHealth : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Image healthBar;
    private bool IsDead;


      public AudioClip winSound;
    private AudioSource win;
    
    public delegate void OnPlayerVictory();
    public  event OnPlayerVictory playerVictoryAction;


    void Awake()
    {
        health = maxHealth;
         win = GetComponent<AudioSource>();
          win.clip=winSound;

    }


    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
            TakeDamage(5);
    }


    private void TakeDamage(int amount)
    {
        if (IsDead)
            return;
        health -= amount;
        healthBar.fillAmount = (float)health / maxHealth;
        if (health <= 0)
        {
             
            EnemyDie();
            playerVictoryAction();
            win.Play();
            
            
           
        }
    }

    private void EnemyDie()
    {
        IsDead = true;
        Destroy(gameObject, 2f);
    }

}
