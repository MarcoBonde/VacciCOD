using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float currScore = 0;

    private void Start()
    {
        currScore = 0;
    }

    public void AddScore(float amount)
    {
        currScore += amount;
    }


}
