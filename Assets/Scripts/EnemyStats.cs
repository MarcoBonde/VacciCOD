using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float scoreAmount = 10;

    GameController gameController;

    private void Start()
    {
       // gameController = GameObject.FindGameObjectsWithTag("GameController").GetComponent<GameController>();
    }

   /* public override void Die()
    {
        gameController.AddScore();
    }*/
}
