using UnityEngine;
using System.Collections;

public class UpdateRoot: MonoBehaviour {

    public static int[] childPositions = { 0, 1, 2, 3 };

    static int[] winningCombo = { 3, 2, 1, 0 };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = IMTargetSensor.currentTransform.position;
        transform.eulerAngles = IMTargetSensor.currentTransform.eulerAngles;

        bool hasWon = true;

        for (int i = 0; i < winningCombo.Length; ++i)
        {
            if (winningCombo[i] != childPositions[i])
                hasWon = false;

            //Debug.Log(childPositions[i]);
        }

        if (hasWon)
            Debug.Log("Youve won !!!!!");
        //else
        //    Debug.Log("Nope !!!");

        


    }
}
