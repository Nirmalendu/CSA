using UnityEngine;
using System.Collections;

public class audiom : MonoBehaviour
{

    int audiovar1 = 0;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (audiovar1 == 0)
        {

            if (GetComponent<MeshRenderer>().enabled)
            {
                AudioSource audios2 = GetComponent<AudioSource>();
                audios2.Play();
                audiovar1 = 1;
            }

            else
            {
                AudioSource audios2 = GetComponent<AudioSource>();
                audios2.Stop();
                audiovar1 = 0;
            }

        }






    }
}
