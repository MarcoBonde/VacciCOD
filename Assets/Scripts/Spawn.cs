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

    public GameObject enemyParent;
    public int maxChildren;
    public float timeAugmentMaxChildren;
    public int childrenIncrement;

    void Start()
    {
        fTimer = fTimeIntervals;
        InvokeRepeating("AumgentMaxChildren", timeAugmentMaxChildren, timeAugmentMaxChildren);
    }

    // Update is called once per frame
    void Update()
    {
        fTimer -= Time.deltaTime;
        if (fTimer <= 0 && enemyParent.transform.childCount<maxChildren)
        {
            fTimer = fTimeIntervals;
            var enemey = Instantiate(goCreate, transform.position, Quaternion.identity);
            enemey.transform.parent = enemyParent.transform;
        }
    }
    void AumgentMaxChildren() {
        maxChildren += childrenIncrement;
    }
}
