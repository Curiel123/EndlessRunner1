using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Spawn Locations")]
    public GameObject spawnLocation;        //Stores the waypoint where fuel and bananas will spawn.
    public GameObject obstacleMiddleSpawnLocation; //stores where obstacles will spawn.
    public GameObject obstacleLeftSpawnLocation; 
    public GameObject obstacleRightSpawnLocation;
    public GameObject enemySpawnLocation;

    public PlayerMovement player;           //Stores the active player script.

    public float currentDistanceTravelled;
    public float distanceMultiplier = 1;
    public int debug;
    private float fuelTimer;
    private float EnemyTimer;
    private float obstacleTimer;
    private float AlienTimer;
    public int randomObstacle;


    [Header("GameObjects")]
    public GameObject fuelObstacle;
    public GameObject enemyObstacle;
    public GameObject alienObstacle;
    public GameObject bananaObstacle;
    public bool speedSwapper = false;           //Alternates between true and false for banana and fuel.

    public List<GameObject> obstaclePrefabs;

    void Start()
    {
        obstaclePrefabs = new List<GameObject>(Resources.LoadAll<GameObject>("Obstacles"));

        //int randomPrefab = Random.Range(0, obstaclePrefabs.Count - 1);
        //Instantiate(obstaclePrefabs[randomPrefab], obstacleSpawnLocation.transform.position, Quaternion.identity);
    }

    void Update()
    {
        FuelTimerMethod();
        AlienTimerMethod();
        EnemyTimerMethod();
        ObstacleTimerMethod();
        DistanceVariableSwapper();
    }

    public void ObstacleTimerMethod()
    {
        if (obstacleTimer > 0)
        {
            obstacleTimer -= Time.deltaTime;
        }

        else if (obstacleTimer <= 0)
        {
            obstacleTimer = 4f * distanceMultiplier;
            BasicObstacleSpawning();
        }
    }

    public void AlienTimerMethod()
    {
        if (AlienTimer > 0)
        {
            AlienTimer -= Time.deltaTime;
        }

        else if (AlienTimer <= 0)
        {
            AlienTimer = 15f / distanceMultiplier;
            AlienSpawning();
        }
    }

    public void EnemyTimerMethod()
    {
        if (EnemyTimer > 0)
        {
            EnemyTimer -= Time.deltaTime;
        }

        else if (EnemyTimer <= 0)
        {
            EnemyTimer = 10f * distanceMultiplier;
            EnemySpawning();
        }
    }

    public void FuelTimerMethod()
    {
        if (fuelTimer > 0)
        {
            fuelTimer -= Time.deltaTime;
        }

        else if (fuelTimer <= 0)
        {
            fuelTimer = 8f * distanceMultiplier;

            if (speedSwapper == false)
            {
                FuelSpawning();
                speedSwapper = true;
            }

            else if (speedSwapper == true)
            {
                BananaSpawning();
                speedSwapper = false;
            }
        }
    }

    //Every 100 units, the current distance traveled will tick up.
    public void DistanceVariableSwapper()
    {
        if (player.totalDistanceTravelled <= currentDistanceTravelled - 100)
        {
            currentDistanceTravelled = player.totalDistanceTravelled;
            debug++;
            distanceMultiplier = distanceMultiplier + 0.1f;
        }
    }

    public void SpawnerManager()
    {
        //Algorithm for deciding what needs to spawn?
    }

    public void AlienSpawning()
    {
        Instantiate(alienObstacle, spawnLocation.transform.position, Quaternion.identity);
    }

    public void FuelSpawning()
    {
        Instantiate(fuelObstacle, spawnLocation.transform.position, Quaternion.identity);
    }

    public void EnemySpawning()
    {
        Instantiate(enemyObstacle, enemySpawnLocation.transform.position, Quaternion.AngleAxis(180, Vector3.right));
    }

    public void BananaSpawning()
    {
        Instantiate(bananaObstacle, spawnLocation.transform.position, Quaternion.identity);
    }

    //Basic spawner script.
    public void BasicObstacleSpawning()
    {
        randomObstacle = Random.Range(0, obstaclePrefabs.Count - 1);

        //Left
        if (player.currentLane == 1)
        {
            Instantiate(obstaclePrefabs[randomObstacle], obstacleLeftSpawnLocation.transform.position, Quaternion.identity);
        }
        
        //Middle
        else if (player.currentLane == 2)
        {
            Instantiate(obstaclePrefabs[randomObstacle], obstacleMiddleSpawnLocation.transform.position, Quaternion.identity);
        }

        //Right
        else if (player.currentLane == 3)
        {
            Instantiate(obstaclePrefabs[randomObstacle], obstacleRightSpawnLocation.transform.position, Quaternion.identity);
        }
    }
}
