﻿using UnityEngine;
using System.Collections;

public class UpdateCharacter : MonoBehaviour {

    static int gridX = 2;
    static int gridY = 2;


    static Vector3[] snapPositions = {
        new Vector3(-100,200, 0),
        new Vector3( 100,200, 0),
        new Vector3(-100,200,-200),
        new Vector3( 100,200,-200),

        //new Vector3(-200,200, 0),
        //new Vector3(-200,200, -200),
        //new Vector3(-100,200,-200),
        //new Vector3( 100,200,-200),
    };

    public int targetNum;

    bool isAcquired = false;

    bool isShown = false;

    int snapPosNum = -1;    

	// Use this for initialization
	void Start () {

        snapPosNum = targetNum;

        this.transform.position = snapPositions[snapPosNum];

    }

    void snapMyPosition()
    {
        int closestSnapIndex = 0;        

        Vector3 p = this.transform.position;

        double curMinDist = (p - snapPositions[0]).sqrMagnitude;

        for (int i = 1; i < snapPositions.Length; ++i)
        {
            double d = (p - snapPositions[i]).sqrMagnitude;
            if ( d < curMinDist)
            {
                closestSnapIndex = i;
                curMinDist = d;
            }
        }

        snapPosNum = closestSnapIndex;

        this.transform.position = snapPositions[snapPosNum];
    }
	
	// Update is called once per frame
	void Update () {

        if (IMTargetSensor.currentIMTarget == targetNum)
            isAcquired = true;

        isShown = ((isAcquired) && (IMTargetSensor.currentIMTarget != -1));

        //Debug.Log("isAc = " + isAcquired + ", targetNum = " + targetNum + "IMTargetSensor.currentIMTarget" + IMTargetSensor.currentIMTarget);

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            // Render only if we are in front of a fiducual and we acquired the object
            r.enabled = isShown;
        }

        foreach (Collider r in GetComponentsInChildren<Collider>())
        {
            // Render only if we are in front of a fiducual and we acquired the object
            r.enabled = isShown;
        }

        if (isShown)
            UpdateRoot.childPositions[targetNum] = snapPosNum;
    }

    // This stores the layers we want the raycast to hit (make sure this GameObject's layer is included!)
    public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;

    // This stores the finger that's currently dragging this GameObject
    private Lean.LeanFinger draggingFinger;

    protected virtual void OnEnable()
    {
        // Hook into the OnFingerDown event
        Lean.LeanTouch.OnFingerDown += OnFingerDown;

        // Hook into the OnFingerUp event
        Lean.LeanTouch.OnFingerUp += OnFingerUp;
    }

    protected virtual void OnDisable()
    {
        // Unhook the OnFingerDown event
        Lean.LeanTouch.OnFingerDown -= OnFingerDown;

        // Unhook the OnFingerUp event
        Lean.LeanTouch.OnFingerUp -= OnFingerUp;
    }

    protected virtual void LateUpdate()
    {
        // If there is an active finger, move this GameObject based on it
        if (draggingFinger != null)
        {
            Lean.LeanTouch.MoveObject(transform, draggingFinger.DeltaScreenPosition);
        }
    }

    public void OnFingerDown(Lean.LeanFinger finger)
    {
        if (!isShown)
            return;

        // Raycast information
        var ray = finger.GetRay();
        var hit = default(RaycastHit);

        // Was this finger pressed down on a collider?
        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
        {
            // Debug.Log("Hit something");

            // Was that collider this one?
            if (hit.collider.gameObject == gameObject)
            {
                // Set the current finger to this one
                draggingFinger = finger;
            }
        }
    }

    public void OnFingerUp(Lean.LeanFinger finger)
    {
        // Was the current finger lifted from the screen?
        if (finger == draggingFinger)
        {
            snapMyPosition();

            // Unset the current finger
            draggingFinger = null;
        }

        
    }
}