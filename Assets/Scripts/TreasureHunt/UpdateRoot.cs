using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateRoot : MonoBehaviour
{

    public static Transform[][] augObjects = { new Transform[4], new Transform[8] };
    public static Vector3[][]   lastPosOfObj = { new Vector3[4] , new Vector3[8] };
    public static bool[][]      objEnabled = { new bool[4], new bool[8] };
    public static bool[][] firstTimeShown = { new bool[4], new bool[8] };
    public static int[]         curSeenObject = { -1, -1 };
    public static bool[] gameCompleted = { false, false };

    public GameObject winText;
    public GameObject demoWinText;
    public GameObject objAcquiredText;
    public GameObject gameCompleteText;

    public AudioSource winAudio;
    public AudioSource acquireAudio;

    float startTime = -1;
    int currentGameIndex;
    static float waitForSeconds = 4;

    // Use this for initialization
    void Start()
    {
        winText.SetActive(false);
        demoWinText.SetActive(false);
        objAcquiredText.SetActive(false);

        winAudio.enabled = false;
        acquireAudio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = IMTargetSensor.currentTransform.position;
        //transform.eulerAngles = IMTargetSensor.currentTransform.eulerAngles;
    }

    bool checkWinningCondition(int gameIndex)
    {
        bool match = true;

        for (int i = 0; i < lastPosOfObj[gameIndex].Length / 2; i++)
        {
            // Check x-coordinate of top (static) objects with bottom ones
            if (lastPosOfObj[gameIndex][i].x != lastPosOfObj[gameIndex][i + lastPosOfObj[gameIndex].Length / 2].x
                || !objEnabled[gameIndex][i] || !objEnabled[gameIndex][i+ lastPosOfObj[gameIndex].Length / 2]
                )
            {
                match = false;
                break;
            }
        }
        if(match)
        {
            currentGameIndex = gameIndex;
        }

        return match;
    }

    void LateUpdate()
    {
        if (IMTargetSensor.currentIMTarget < 0 || IMTargetSensor.currentIMTarget >=12)
        {
            curSeenObject[0] = -1;
            curSeenObject[1] = -1;
            currentGameIndex = -1;
        }
        else if(IMTargetSensor.currentIMTarget < 4)
        {
            curSeenObject[0] = IMTargetSensor.currentIMTarget;
            currentGameIndex = 0;
            curSeenObject[1] = -1;
        }

        else if (IMTargetSensor.currentIMTarget < 12)
        {
            curSeenObject[0] = -1;
            curSeenObject[1] = IMTargetSensor.currentIMTarget - 4;
            currentGameIndex = 1;
        }

        if(currentGameIndex != -1)
        {
            if (firstTimeShown[currentGameIndex][curSeenObject[currentGameIndex]] && 
                !gameCompleted[currentGameIndex])
            {
                if (startTime == -1)
                {
                    startTime = Time.time;
                    objAcquiredText.SetActive(true);
                    acquireAudio.enabled = true;
                    //GetComponent<AudioSource>().enabled = true;
                }
                if (Time.time > startTime + waitForSeconds / 4)
                {
                    startTime = -1;
                    firstTimeShown[currentGameIndex][curSeenObject[currentGameIndex]] = false;
                    objAcquiredText.SetActive(false);
                }
            }
            else
            {
                //GetComponent<AudioSource>().enabled = false;
                acquireAudio.enabled = false;
            }
        }

        if(IMTargetSensor.currentIMTarget!=-1)
        {
            if (gameCompleted[currentGameIndex])
            {
                gameCompleteText.SetActive(true);
            }
        }
        else
        {
            gameCompleteText.SetActive(false);
        }
        
        if (checkWinningCondition(0))
        {
            //winText.text = "Great !! You've Got the idea!";

            if (!gameCompleted[currentGameIndex])
            {
                demoWinText.SetActive(true);
                winAudio.enabled = true;
                //Debug.Log("Win!");
                if (startTime == -1)
                {
                    startTime = Time.time;
                    //Debug.Log("Start time is " + startTime);
                }
                if (Time.time > startTime + waitForSeconds)
                {
                    demoWinText.SetActive(false);
                    startTime = -1;
                    //Debug.Log("End time is " + Time.time);
                    gameCompleted[currentGameIndex] = true;
                }
            }
            else
            {
                winAudio.enabled = false;
            }
        }


        if (checkWinningCondition(1))
        {
            //winText.text = "Congratulations!! you've Picked up all the clues !! \n " +
            //    "Visit 311 for your Gifts (Subject to availability )!!";
            if(!gameCompleted[currentGameIndex])
            {
                winText.SetActive(true);
                //Debug.Log("Win!");
                if (startTime == -1)
                {
                    startTime = Time.time;
                    winAudio.enabled = true;
                    //GetComponent<AudioSource>().enabled = true;
                    //Debug.Log("Start time is " + startTime);
                }
                if (Time.time > startTime + waitForSeconds)
                {
                    winText.SetActive(false);
                    startTime = -1;
                    //Debug.Log("End time is " + Time.time);
                    gameCompleted[currentGameIndex] = true;
                    Application.LoadLevelAsync(1);
                }

            }

            else
            {
                winAudio.enabled = false;
            }
        }

    }
}
