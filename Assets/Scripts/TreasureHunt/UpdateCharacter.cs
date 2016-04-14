using UnityEngine;
using System.Collections;

public class UpdateCharacter : MonoBehaviour
{

    public bool isStaticObj;
    public int objectNum;
    public int gameIndex;

    static Vector3[] snapPositions1 = {
        new Vector3( -80,100, -100),
        new Vector3( 80,100, -100),
    };


    static Vector3[] snapPositions2 = {
        new Vector3(-240,100, -100),
        new Vector3( -80,100, -100),
        new Vector3( 80,100, -100),
        new Vector3( 240,100, -100),
    };



    static Vector3[][] snapPositions = { snapPositions1, snapPositions2 };


    bool isAcquired = false;
    bool isShown = false;

    //bool isAcquired = true;
    //bool isShown = true;

    int snapPosNum = -1;
    

    // Use this for initialization
    void Start()
    {
        UpdateRoot.augObjects[gameIndex][objectNum] = transform;
        UpdateRoot.lastPosOfObj[gameIndex][objectNum] = transform.position;
        UpdateRoot.objEnabled[gameIndex][objectNum] = false;
        UpdateRoot.firstTimeShown[gameIndex][objectNum] = true;
    }

    void snapMyPosition()
    {
        int closestSnapIndex = 0;

        Vector3 p = this.transform.position;

        double curMinDist = (p - snapPositions[gameIndex][0]).sqrMagnitude;

        for (int i = 1; i < snapPositions[gameIndex].Length; ++i)
        {
            double d = (p - snapPositions[gameIndex][i]).sqrMagnitude;
            if (d < curMinDist)
            {
                closestSnapIndex = i;
                curMinDist = d;
            }
        }


        snapPosNum = closestSnapIndex;
        //Debug.Log("Snap position is " + snapPositions[gameIndex][snapPosNum]);

        Vector3 newPosition = snapPositions[gameIndex][snapPosNum];

        for (int i = 0; i < UpdateRoot.augObjects[gameIndex].Length; i++)
        {
            if (UpdateRoot.lastPosOfObj[gameIndex][i] == newPosition)
            {
                UpdateRoot.augObjects[gameIndex][i].position = UpdateRoot.lastPosOfObj[gameIndex][objectNum];
                UpdateRoot.lastPosOfObj[gameIndex][i] = UpdateRoot.lastPosOfObj[gameIndex][objectNum];
                //Debug.Log("Object to be swapped is " + UpdateRoot.augObjects[gameIndex][i].name);
                //Debug.Log("Target position is " + UpdateRoot.lastPosOfObj[gameIndex][objectNum]);
            }
        }

        transform.position = newPosition;
        UpdateRoot.lastPosOfObj[gameIndex][objectNum] = newPosition;
    }

    // Animation data to move image from fiducial to position on acquire
    //double lerpTimeBeg;
    //double lerpTimeSpan = 5;

    // Update is called once per frame
    void Update()
    {

        if (UpdateRoot.curSeenObject[gameIndex] == objectNum)
        {
            //if (isAcquired == false)
            //{
            //    lerpTimeBeg = Time.time;
            //}

            isAcquired = true;
            UpdateRoot.objEnabled[gameIndex][objectNum] = true;
        }

        //if (isAcquired)
        //{
        //    UpdateRoot.objEnabled[gameIndex][objectNum] = true;
        //}
        //isShown = isAcquired;


        ////if (Time.time <= lerpTimeBeg + lerpTimeSpan && Time.time > lerpTimeBeg && isAcquired)
        ////{
        ////    float t = (float)((Time.time - lerpTimeBeg) / lerpTimeSpan);
        ////    transform.position = snapPositions[snapPosNum] * t;
        ////}

        isShown = ((isAcquired) && (UpdateRoot.curSeenObject[gameIndex] != -1) && !UpdateRoot.gameCompleted[gameIndex]);

        //if (isShown && firstTimeShown)
        //{
        //    if (Time.time < startTime + 2)
        //    {
        //        transform.position = new Vector3(0, 50, 0);
        //    }
        //    else
        //    {
        //        transform.position = UpdateRoot.lastPosOfObj[gameIndex][objectNum];
        //        firstTimeShown = false;
        //    }
        //}

        ////Debug.Log("isAc = " + isAcquired + ", objectNum = " + objectNum + "IMTargetSensor.currentIMTarget" + IMTargetSensor.currentIMTarget);

        if (UpdateRoot.gameCompleted[gameIndex])
        {
            isShown = false;
        }

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            // Render only if we are in front of a fiducual and we acquired the object
            r.enabled = isShown;
        }

        foreach (Collider r in GetComponentsInChildren<Collider>())
        {
            r.enabled = isShown;
        }
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
        if (!isShown || isStaticObj)
        {
            //Debug.Log("Object" + objectNum + " is not shown");
            return;
        }

        // Raycast information
        var ray = finger.GetRay();
        var hit = default(RaycastHit);

        // Was this finger pressed down on a collider?
        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
        {
            //Debug.Log("Hit something  object" + hit.collider.gameObject.name);
            //Debug.Log("Name is " + gameObject.name);

            // Was that collider this one?
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Object" + objectNum + " was the collider");

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
