using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextGenerator healthAmount, staminaAmount;

    CharacterStats playerStats;

    void Start()
    {
        playerStats = GetComponent<CharacterStats>();     

    }

   
}
