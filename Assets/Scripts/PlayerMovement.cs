using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Player Movement Class
public class PlayerMovement : MonoBehaviour
{
    [Header("Ship Stats")]
    public float speed;                         //Forward speed of the player.
    public float fuel = 100;                    //Stores the current fuel of the player
    public float playerHealth = 3f;             //Player health whenever they collide with an enemy beam
    public float currency = 0f;                 //How many alien hitch-hikers the player has collected.

    [Header("Ship Configuration")]                     
    public bool hasLaunched = false;            //Detects if the player has launched the ship.
    public int currentLane = 2;                 //Stores the current lane of the player.
    private float fuelTimer;                    //A variable used for the timer attached to the fuel mechanic.
    public bool fuelControlDisabler;            //Detects if the player's controls should be active or not.

    public float totalDistanceTravelled;           //Distance travelled stored as Int.

    [Header("GameObject Positions")]
    public Vector3 startPosition;                //Stores the starting position of the player.
    public Vector3 currentPosition;              //Stores the current position of the player.
    public Vector3 distanceTravelled;            //Stores the distance traveled.
    public Vector3 movementLeft;
    public Vector3 movementRight;

    [Header("HUD References")]
    public SliderScript fuelBar;                    //Stores the fuel bar for the hud.

    void Start()
    {
        startPosition = transform.position;                 //Saves the starting location so current can be compared to it.
    }

    void Update()
    {
        fuelBar.SetFuel(fuel);                              //Updates the fuel bar on the HUD every frame.

        if (hasLaunched == true)
        {
            transform.position += -transform.right * speed * Time.deltaTime;            //Moves the player.
            DistanceCalculator();
            FuelDegradation();
            LaneMovement();
        }

        else
        {
            if (Input.GetKeyDown("space"))
            {
                hasLaunched = true;                         //The player must manually start the game.
                GameTimer.timerInstance.BeginTimer();
            }
        }
    }

    //Fuel consumption
    public void FuelDegradation()
    {
        //Loops from 2 to 0, will count each time the fuel should tick down.
        if (fuelTimer > 0)
        {
            fuelTimer -= Time.deltaTime;
        }

        else if (fuelTimer <= 0)
        {
            fuel = fuel - 10;
            fuelTimer = 4;
        }

        //Disables and enables the player control variable.
        if (fuel <= 0)
        {
            fuel = 0;
            fuelControlDisabler = true;
        }

        else if (fuel > 0)
        {
            fuelControlDisabler = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fuel")
        {
            fuel = 100;                                     //Upon colliding with a collectable, fuel is set back to 100
            speed++;
            Destroy(other.gameObject);                      //Destroys the game object
        }

        else if (other.tag == "Alien")
        {
            Destroy(other.gameObject);
            currency++;
        }

        else if (other.tag == "Beam")
        {
            playerHealth--;
        }

        else if (other.tag == "Obstacle")
        {
            Destroy(other.gameObject); //Ensures they can't hit it twice.
            //Play Sound Effect
            //Play Animation
            playerHealth--;
        }

        else if (other.tag == "Banana")
        {
            speed--;
            Destroy(other.gameObject);
        }
    }

    //Player Movement Controls
    public void LaneMovement()
    {
        if (fuelControlDisabler == false)
        {
            //Moves the player left based on coordinates
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (currentLane == 2)
                {
                    //transform.position = Vector3.Lerp(transform.position, movementLeft, speed * Time.deltaTime);
                    transform.position += new Vector3(0, 0, -10);
                    currentLane = 1;
                }
                else if (currentLane == 3)
                {
                    //transform.position = Vector3.Lerp(transform.position, movementLeft, speed * Time.deltaTime);
                    transform.position += new Vector3(0, 0, -10);
                    currentLane = 2;
                }
            }
            //Moves the player right based on coordinates
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (currentLane == 1)
                {
                    transform.position += new Vector3(0, 0, +10);
                    currentLane = 2;
                }
                else if (currentLane == 2)
                {
                    transform.position += new Vector3(0, 0, +10);
                    currentLane = 3;
                }
            }
        }
    }

    public void DistanceCalculator()
    {
        currentPosition = transform.position;
        distanceTravelled = currentPosition - startPosition;         //Rudimentary way of calculating distance travelled.
        totalDistanceTravelled = distanceTravelled.x;
    }
}
