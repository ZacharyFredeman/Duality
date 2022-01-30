using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{

    private float countdown = 5;
    private bool phase1;
    private bool countdownB;
    private bool phase2;
    private bool timerStart;
    private float time;
    private bool joust;
    private bool winner;
    private float CountDtime;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        bool countdownB = true;
        bool phase1 = false;
        bool phase2 = false;
        bool timerStart = false;
        bool joust = false;
        bool winner = true;
       
    }

    // Update is called once per frame
    void Update()
    {
         //Debug.Log(countdownB);
        if (!countdownB)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
                Debug.Log(countdown);
            }
            if(countdown < 0)
            {
                Debug.Log("countdown done");
                countdown = 0;
                countdownB = true;
                phase1 = true;
                winner = true;
            }
        }
        // Debug.Log(phase1);

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
        //Debug.Log("Phase1");    

        //start timer for win checking
        if (timerStart == false)
        {
            Debug.Log("Phase1");
            timerStart = true;
            CountDtime = Time.deltaTime;
            time = Time.deltaTime;
        }
        CountDtime += Time.deltaTime;
        Debug.Log(CountDtime);
        //check for key press
        if (Input.GetKeyDown("w") && joust != true)
        {
            joust = true;
            time -= Time.deltaTime;
            Debug.Log(time);
            winner = false;
        }
        else if (CountDtime > 5) //auto lose for wrong key
        {
            joust = true;
            Debug.Log("YOU SUCK");
        }

        //determine winner
        //calc score
        if (winner == false)
        {
            phase1 = false;
            phase2 = true;
        }

    }

    void Phase2()
    {
        //Debug.Log("Hello Phase 2");
        string[] keycombo = new string[4] { "w", "a", "s", "d" };
        string keyI = keycombo[i];
        if (Input.GetKeyDown("w"))
        {
            if ("w" == keyI)
            {
                Debug.Log("SUccess");
                i++;
            }
            else
            {
                Debug.Log("Fail");
            }
        }

        else if (Input.GetKeyDown("a"))
        {
            if ("a" == keyI)
            {
                Debug.Log("SUccess");
                i++;
            }
            else
            {
                Debug.Log("Fail");
            }
        }

        else if (Input.GetKeyDown("s"))
        {
            if ("s" == keyI)
            {
                Debug.Log("SUccess");
                i++;
            }
            else
            {
                Debug.Log("Fail");
            }
        }

        else if (Input.GetKeyDown("d"))
        {
            if ("d" == keyI)
            {
                Debug.Log("SUccess");
                i++;
            }
            else
            {
                Debug.Log("Fail");
            }
        }

    }
}
