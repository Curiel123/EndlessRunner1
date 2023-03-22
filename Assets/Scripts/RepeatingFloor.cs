using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Repeating Floor Class
/// 
/// Once the player gets to the end of the starting platform, this class spawns the next one
/// to make the game repeat the further the UFO goes.
/// </summary>

public class RepeatingFloor : MonoBehaviour
{
    //Game object variable for the second platform to spawn
    public GameObject toSpawnPlatforms;

    //Upon colliding with a placed waypoint once the player has moved into its collision zone, the next platform is spawned
    //specifically at the end x axis of -200 each time. This is iterative and increases the further the player moves
    //forward.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            toSpawnPlatforms.transform.Translate(-200, 0, 0);
        }
    }
}
