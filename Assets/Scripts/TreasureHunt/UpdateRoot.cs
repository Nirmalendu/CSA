using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateRoot : MonoBehaviour
{

    public static Transform[] augObjects = new Transform[8];
    public static Vector3[] lastPosOfObj = new Vector3[8];

    public static bool matchingConditionMet = false;
    bool match;

    public Text winText;
    // Use this for initialization
    void Start()
    {
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = IMTargetSensor.currentTransform.position;
        //transform.eulerAngles = IMTargetSensor.currentTransform.eulerAngles;
    }

    void LateUpdate()
    {
        match = true;
        for (int i = 0; i < 4; i++)
        {
            // Check x-coordinate of top (static) objects with bottom ones
            if (lastPosOfObj[i].x != lastPosOfObj[i + 4].x)
            {
                match = false;
                break;
            }
        }
        if (match)
        {
            matchingConditionMet = true;
            winText.text = "Congratulations! Great Job!";
            //Debug.Log("Matching condition met!");
        }
    }
}
