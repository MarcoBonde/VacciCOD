using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;
    public int maxStamina = 100;
    private float currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.01f);
    private Coroutine regen;

    public static Stamina instance;
    public FirstPersonController player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
   
    void FixedUpdate()
    {
        if(currentStamina > 10)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                UseStamina(0.5f);
            }
            player.m_RunSpeed = 10f;
            player.m_WalkSpeed = 5f;
        } else
        {
            player.m_IsWalking = true;
            staminaBar.value = currentStamina;
            player.m_RunSpeed = 3f;
            player.m_WalkSpeed = 5f; 
        }
    }

    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(5);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }
}