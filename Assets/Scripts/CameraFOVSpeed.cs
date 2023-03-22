using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera FOV (Field of View) Class
/// 
/// Ties the camera position to the speed of which the player UFO is moving as they progress
/// on a longer run/playthrough before crashing.
/// </summary>

public class CameraFOVSpeed : MonoBehaviour
{
    public PlayerMovement playerSettings;       //Stores the current player script.
    public Camera setCamera;                    //Stores the current camera.

    //Sets the default camera FOV to 70.
    void Start()
    {
        setCamera.fieldOfView = 70f;
    }

    //Calls function as the game runs
    void Update()
    {
        cameraFOV();
    }

    //Function to change the player's FOV based on their current speed.
    public void cameraFOV()
    {
        switch (playerSettings.speed)
        {
            case 10:
                setCamera.fieldOfView = 70f;
                break;
            case 11:
                setCamera.fieldOfView = 71f;
                break;
            case 12:
                setCamera.fieldOfView = 72f;
                break;
            case 13:
                setCamera.fieldOfView = 73f;
                break;
            case 14:
                setCamera.fieldOfView = 74f;
                break;
            case 15:
                setCamera.fieldOfView = 75f;
                break;
            case 16:
                setCamera.fieldOfView = 76f;
                break;
            case 17:
                setCamera.fieldOfView = 77f;
                break;
            case 18:
                setCamera.fieldOfView = 78f;
                break;
            case 19:
                setCamera.fieldOfView = 79f;
                break;
            case 20:
                setCamera.fieldOfView = 80f;
                break;
            case 21:
                setCamera.fieldOfView = 81f;
                break;
            case 22:
                setCamera.fieldOfView = 82f;
                break;
            case 23:
                setCamera.fieldOfView = 83f;
                break;
            case 24:
                setCamera.fieldOfView = 84f;
                break;
            case 25:
                setCamera.fieldOfView = 85f;
                break;
            case 26:
                setCamera.fieldOfView = 86f;
                break;
            case 27:
                setCamera.fieldOfView = 87f;
                break;
            case 28:
                setCamera.fieldOfView = 88f;
                break;
            case 29:
                setCamera.fieldOfView = 89f;
                break;
            case 30:
                setCamera.fieldOfView = 90f;
                break;
        }
    }
}
