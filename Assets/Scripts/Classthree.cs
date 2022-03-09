using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classthree : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed;
    public Vector3 direction;
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currenHealth;
    private bool isDead;

    private void Start()
    {
        //Vida Completa
        currenHealth = maxHealth; 
    }

    private void Update()
    {
        MovePlayer(direction);

        //Con Barra se ejecuta funcion take damage 40
        if(Input.GetKeyDown(KeyCode.Space) && !isDead) 
        {
            TakeDamage(40);
        }
        if (Input.GetKeyDown(KeyCode.H) && !isDead)  
            //Con Tecla H se cura
        {
            HealPlayer(40);
        }
    }

    private void MovePlayer(Vector3 dir)
    {
        transform.position += dir.normalized * speed;
    }

    public void TakeDamage(int amount) 
    {
        currenHealth -= amount;
        if (currenHealth <= 0) //Valor no puede ser menor a cero
        {
            currenHealth = 0;
            //Funcion de muerte
            Debug.Log("Player is Dead");
            isDead = true;
        }
        Debug.Log("Damage Taken: " + amount + " Remaining Health: " + currenHealth);
    }

    private void HealPlayer(int healingAmount)
    {
        currenHealth += healingAmount;

        if(currenHealth >= maxHealth) 
        {
            currenHealth = maxHealth;
            Debug.Log("Player is full Health");
        }
        Debug.Log("Player is healed, currentHealth is: " + currenHealth);
        
    }

}
