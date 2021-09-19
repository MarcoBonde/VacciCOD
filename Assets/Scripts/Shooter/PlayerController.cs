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
    public GameObject spawners;
    public Image blood;
    private float alpha;
    private float lastReset;
    private void OnEnable()
    {
        singleton = this;
        isHitten = false;
        alpha = 0f;
        StartCoroutine("SubstractOne");
        StartCoroutine("AddOne");
    }

    /*void UpdateHealth()
    {
        Color splatterAlpha = redSplatterImage.color;
        splatterAlpha.a = 1 - health / health;
    }*/
    public void Update()
    {
        if (alpha > 0f)
        {
            changeAlphaBlood(alpha);
        }
        else {
            changeAlphaBlood(0f);
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        //print("COLLIDO");
        if (coll.collider.CompareTag("Enemy") && !isHitten)
        {
            //print("E prendo Danno");
            isHitten = true;
            health -= 20f;
            alpha = 0.8f;
            Invoke("isHittenFalse", invincibleTime);
        }
        if (health < 1) {
            gameOverRoutine();
        }
    }
    public void gameOverRoutine() {
        //ferma il gioco
        GetComponent<CapsuleCollider>().enabled=false;
        spawners.SetActive(false);
        gameOverEvent.Invoke();
    }
    public void isHittenFalse() {
        isHitten = false;
    }
    private void changeAlphaBlood(float how)
    {
        var tempColor = blood.color;
        tempColor.a = how;
        blood.color = tempColor;
    }
    IEnumerator SubstractOne() {
        while (true)
        {
            alpha -= 0.04f;
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator AddOne()
    {
        while (true)
        {
            if (alpha < 0 && health<100)
            {
                health += 1f;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
