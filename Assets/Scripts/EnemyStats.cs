using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float scoreAmount = 10;

    GameController gameController;
    Spawner spawn;
    private void Start()
    {
        // gameController = GameObject.FindGameObjectsWithTag("GameController").GetComponent<GameController>();

       /* maxHealth = 100;
        currHealth = maxHealth;

        maxStamina = 100;
        currStamina = maxStamina;*/
    }

    private void Update()
    {
       // CheckHealth();
    }

    /* public override void Die()
     {
         gameController.AddScore();
         Destroy(gameObject);
     }*/
}
