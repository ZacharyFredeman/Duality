using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerswPhase2 : MonoBehaviour
{

    public float countdown = 5;
    public float phase1Countdown = 5;
    private bool phase1;
    private bool countdownB;
    private bool phase2;
    private bool timerStart;
    private float time;
    private bool joust = false;
    public bool timesUp;
    public bool Player1Wins = false; // bools to handle victory
    public bool Player2Wins = false;
    [SerializeField] GameObject Player1Object;
    [SerializeField] GameObject Player2Object;
    private int i = 0;
    private int z = 0;

    // Start is called before the first frame update
    void Start()
    {
        bool countdownB = true;
        bool phase1 = false;
        bool phase2 = false;
        bool timerStart = false;
        bool joust = false;
        bool timesUp = false;


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(phase1);
        if (!countdownB)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
                Debug.Log(countdown);
            }
            else
            {
                Debug.Log("countdown done");
                countdownB = true;
                countdown = 0;
                phase1 = true;
            }
        }

        if (timerStart) //Phase1 timer triggered, begin counting
        {
            
        }
        //Debug.Log(phase1);
        
        if (phase1 == true)
        {
            timerStart = true; //Set start timer flag used in Phase1
            Phase1();
            //phase1 = false; // Set phase1 to false, else it will re-trigger every update
        }
        else if (phase2 == true)
        {
            Phase2();
            //phase2 = false;
        }
       // checkInput();

    }

    void Phase1()
    {
        
        //Debug.Log("Phase1");    

        //Players have 5 seconds to hit a button, start counting
        //Set flag to start counting, compute in Update()
        if (timerStart == true)
        {
            
            if (phase1Countdown > 0) // Phase1 timer needs to be accessed in Update()
            {
                Debug.Log("phase1Countdown: " + phase1Countdown);
                phase1Countdown -= Time.deltaTime;
            }
            else{
                
                timesUp = true; //Counter is 0, set "end match" flag
                timerStart = false; // Stop timer flag
            }
            
            
        }

        if(timesUp) //Timer ran out
                {
                    //joust = true;
                    phase2 = true; //Nobody won, call Phase2
                    Debug.Log("Time is up! Draw. Begin Phase2");
                    phase1 = false;
                    return;
                }

        
                //check for key press
        if (Input.GetKeyDown(KeyCode.W) && joust != true) // Player 1 strikes first
        {
            Debug.Log("Player 1 strikes first!");
            joust = true;
            Player1Wins = true;
            timerStart = false; // Match is over, stop timer
        }

       else if (Input.GetKeyDown(KeyCode.UpArrow) && !joust) // Player 2 strikes first
        {
            Debug.Log("Player 2 strikes first!");
            joust = true;
            Player2Wins = true;
            timerStart = false;
        }
       
        //This if possibly doesn't need to keep track of joust time, but maybe we set some other flags here, since *somebody* won 
        //Might be helper code for when Player1Wins/Player2Wins is processed
        if(joust == true)
        {
            time -= Time.deltaTime;
            Debug.Log("Joust time: " + time);
        }


        if(Player1Wins)
        {
            Debug.Log("PLAYER 1 WINS!");
            return;
        }

        if(Player2Wins)
        {
            Debug.Log("Player 2 WINS!");
            return;
        }
    }

    void Phase2()
    {
        //Debug.Log("Hello Phase 2");
        string[] keycombo1 = new string[4] { "w", "a", "s", "d" };  
        if (i != 4 && z != 4)
        {
            string keyI = keycombo1[i];
			string key2 = keycombo1[z];
            Debug.Log("enter key " + keyI + "or " + key2);
			//player 1
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
			
			
			//player 2
			if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if ("w" == key2)
                {
                    Debug.Log("SUccess");
                    z++;
                }
                else
                {
                    Debug.Log("Fail");
                }
            }
			
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if ("a" == key2)
                {
                    Debug.Log("SUccess");
                    z++;
                }
                else
                {
                    Debug.Log("Fail");
                }
            }
			
			else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if ("s" == key2)
                {
                    Debug.Log("SUccess");
                    z++;
                }
                else
                {
                    Debug.Log("Fail");
                }
            }
			
			else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if ("d" == key2)
                {
                    Debug.Log("SUccess");
                    z++;
                }
                else
                {
                    Debug.Log("Fail");
                }
            }
			
			if(i == 4){
				//player 1 wins
			}
			
			if(z == 4){
			//player 2 wins
			}
        }

    }
   
}
