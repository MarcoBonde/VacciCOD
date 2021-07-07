using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public float currStamina;
    public float maxStamina;

    public bool isDead = false;

    public void CheckHealth()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }

    public void CheckStamina()
    {
        if (currStamina >= maxStamina)
        {
            currStamina = maxStamina;
        }
        if (currStamina <= 0)
        {
            currStamina = 0;
        }
    }

    public virtual void Die()
    {
        //Override.
    }

}
