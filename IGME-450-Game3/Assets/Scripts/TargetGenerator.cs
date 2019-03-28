﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    // set up fields
    public GameObject targetPrefab;

    public GameObject upperArm;
    public GameObject lowerArm;

    private GameObject target;

    private CircleCollider2D targetCollider;
    private BoxCollider2D upperArmCollider;
    private BoxCollider2D lowerArmCollider;

    // Use this for initialization
    void Start()
    {
        CreateTarget();

        targetCollider = target.GetComponent<CircleCollider2D>();
        upperArmCollider = upperArm.GetComponent<BoxCollider2D>();
        lowerArmCollider = lowerArm.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (targetCollider.IsTouching(upperArmCollider))
        {
            Destroy(target);

            CreateTarget();
            targetCollider = target.GetComponent<CircleCollider2D>();
        }
        if (targetCollider.IsTouching(lowerArmCollider))
        {
            Destroy(target);

            CreateTarget();
            targetCollider = target.GetComponent<CircleCollider2D>();
        }

    }

    // Creates a target randomly within the space of the stage
    void CreateTarget()
    {
        target = Instantiate(targetPrefab, new Vector2(Random.Range(-4f, 4f), Random.Range(-.5f, 2f)), Quaternion.identity);
    }
}
