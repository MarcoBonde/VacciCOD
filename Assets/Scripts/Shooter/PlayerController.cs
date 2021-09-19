using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;
    public float health = 100f;
    bool isHitten;
    public float invincibleTime;
    public UnityEvent gameOverEvent;
    //private BloodEffect = null;

    private void OnEnable()
    {
        singleton = this;
        isHitten = false;
    }

    /*void UpdateHealth()
    {
        Color splatterAlpha = redSplatterImage.color;
        splatterAlpha.a = 1 - health / health;
    }*/

    void OnCollisionEnter(Collision coll)
    {
        //print("COLLIDO");
        if (coll.collider.CompareTag("Enemy") && !isHitten)
        {
            //print("E prendo Danno");
            isHitten = true;
            health -= 20f;
            Invoke("isHittenFalse", invincibleTime);
        }
        if (health < 1) {
            gameOverRoutine();
        }
    }
    public void gameOverRoutine() {
        //ferma il gioco
        gameOverEvent.Invoke();
    }
    public void isHittenFalse() {
        isHitten = false;
    }
}
