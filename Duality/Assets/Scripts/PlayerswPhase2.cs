using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerswPhase2 : MonoBehaviour
{

    public float countdown = 5;
    public float phase1Countdown = 5;
    private bool phase1;
    private bool countdownB;
    private bool phase2;
    private bool timerStart = true;
    private float time;
    private bool joust = false;
    public bool timesUp;
    public bool Player1Wins = false; // bools to handle victory
    public bool Player2Wins = false;
    [SerializeField] GameObject Player1Object;
    [SerializeField] GameObject Player2Object;
    private int i = 0;
    private int z = 0;
    public int p1wins = 0;
    public int p2wins = 0;

    private Animator evil;
    private Animator good;

    // Start is called before the first frame update
    void Start()
    {
        // bool countdownB = true;
        //bool phase1 = false;
        //bool phase2 = false;
        //bool timerStart = false;
        //bool joust = false;
        //bool timesUp = false;
        evil = GetComponent<Animator>();
        good = GetComponent<Animator>();

        countdown = Random.Range(2, 7);
        phase1Countdown = Random.Range(2, 7);
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
        
        if (phase1 == true)
        {
            //timerStart = true; //Set start timer flag used in Phase1
            Phase1();
            //phase1 = false; // Set phase1 to false, else it will re-trigger every update
        }
        else if (phase2 == true)
        {
            Phase2();
            //phase2 = false;
        }
        else if (Input.GetKeyDown("space"))
        {
            Debug.Log("Spaceee");
            resetGameState();
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


            //check for key press
            if (Input.GetKeyDown(KeyCode.W) && joust != true) // Player 1 strikes first
            {
                Debug.Log("Player 1 strikes first!");
                joust = true;
                Player1Wins = true;
                timerStart = false; // Match is over, stop timer
                //animation
                evil.SetTrigger("block");
                good.SetTrigger("gattack");
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow) && !joust) // Player 2 strikes first
            {
                Debug.Log("Player 2 strikes first!");
                joust = true;
                Player2Wins = true;
                timerStart = false;

                //animation
                evil.SetTrigger("attack");
                good.SetTrigger("gblock");
            }

            //This if possibly doesn't need to keep track of joust time, but maybe we set some other flags here, since *somebody* won 
            //Might be helper code for when Player1Wins/Player2Wins is processed
            if (joust == true)
            {
                time -= Time.deltaTime;
                Debug.Log("Joust time: " + time);
            }


            if (Player1Wins)
            {
                Debug.Log("PLAYER 1 WINS!");
                p1wins += 1;
                checkWinner();
            }

            if (Player2Wins)
            {
                Debug.Log("Player 2 WINS!");
                p2wins += 1;
                checkWinner();
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
                Debug.Log("Player 1 wins");
                p1wins += 1;
                evil.SetTrigger("block");
                good.SetTrigger("gattack");
                checkWinner();

            }
			
			if(z == 4){
                Debug.Log("Player 2 wins");
                p2wins += 1;
                evil.SetTrigger("attack");
                good.SetTrigger("gblock");
                checkWinner();
            }
        }

    }

    void resetGameState()
    {
        countdownB = false;
        
        Player1Wins = false;
        Player2Wins = false;
        joust = false;
        timerStart = true;
        countdown = Random.Range(2, 7);
        phase1Countdown = Random.Range(2, 7);
    }

    void checkWinner()
    {
        phase1 = false;
        phase2 = false;

        int wscrean = p1wins - p2wins;
        

        if((p1wins - p2wins) >= 3)
        {
            Debug.Log("Player 1 is ruler");
            good.SetTrigger("gwin");
            //SceneManager.LoadScene(DeathVictory, LoadSceneMode.Single);
        }

        else if((p2wins - p1wins >= 3))
        {
            Debug.Log("Player 2 is ruler");
            evil.SetTrigger("win");
           // SceneManager.LoadScene(DeathVictory, LoadSceneMode.Single);
        }

        return;

    }
   
}
