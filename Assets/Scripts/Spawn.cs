using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject goCreate;

    [SerializeField]
    float fTimeIntervals;

    [SerializeField]
    Vector3 v4SpawnPosJitter;

    float fTimer = 0;
    

    void Start()
    {
        fTimer = fTimeIntervals;
    }

    // Update is called once per frame
    void Update()
    {
        fTimer -= Time.deltaTime;
        if (fTimer <= 0)
        {
            fTimer = fTimeIntervals;
            Instantiate(goCreate, transform.position, Quaternion.identity);
        }
    }
}
