using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{

    public float countdown = 5;
    private bool phase1;
    private bool countdownB;
    private bool phase2;
    private bool timerStart;
    private float time;
    private bool joust;

    // Start is called before the first frame update
    void Start()
    {
        bool countdownB = true;
        bool phase1 = false;
        bool phase2 = false;
        bool timerStart = false;
        bool joust = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(phase1);
        if (countdown > 0 )
        {
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
        }else {
            Debug.Log("countdown done");
            countdown = 0;
            //countdownB = false;
            phase1 = true;
        }
        Debug.Log(phase1);
        
        if (phase1 == true)
        {
            Phase1();
        }
        else if (phase2 == true)
        {
            Phase2();
        }

    }

    void Phase1()
    {
        Debug.Log("Phase1");    

        //start timer for win checking
        if (timerStart = false)
        {
            timerStart = true;
            time = Time.deltaTime;
        }

        //check for key press
        if (Input.GetKeyDown("w") && joust != true)
        {
            joust = true;
        }
        else //auto lose for wrong key
        {
            joust = false;
        }


        if(joust == true)
        {
            time -= Time.deltaTime;
            Debug.Log(time);
        }


    }

    void Phase2()
    {

    }
}
