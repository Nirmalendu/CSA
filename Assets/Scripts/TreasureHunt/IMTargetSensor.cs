﻿using UnityEngine;
using System.Collections;

public class IMTargetSensor : MonoBehaviour
{

    public static int currentIMTarget = -1;
    public static Transform currentTransform;

    public int targetNum;


    public static bool[] targetsEnabled = new bool[16];
    public static Transform[] targetsTransforms = new Transform[16];


    void Start()
    {
    }

    void Update()
    {
        targetsEnabled[targetNum] = GetComponent<MeshRenderer>().enabled;
        targetsTransforms[targetNum] = GetComponentInParent<Transform>();
    }

    void LateUpdate()
    {
        bool noActiveTarget = true;

        for (int i = 0; i < targetsEnabled.Length; ++i)
        {
            if (targetsEnabled[i])
            {
                currentIMTarget = i;
                noActiveTarget = false;
            }
        }

        if (noActiveTarget)
            currentIMTarget = -1;
        else
            currentTransform = targetsTransforms[currentIMTarget];

    }

}
