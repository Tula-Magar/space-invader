using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTests : MonoBehaviour
{
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private EnemyManager enemyManager;

    public GameObject enemyShip;
    public GameObject playerProjectile;

    private float timerRunTests;
    private bool testOnce;
    private bool checkOnce;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        timerRunTests = 0;
        testOnce = true;
        checkOnce = true;
    }

    void Update()
    {
        timerRunTests += Time.deltaTime;

        // collision was too slow to checked in time, needed to be split up
        if (timerRunTests >= 1.0f && testOnce == true) { TestGame(); }
        if (timerRunTests >= 1.2f && checkOnce == true) { CheckTests(); }
    }

    private void TestGame()
    {
        testOnce = false;

        // tests enemy collision by 'crashing' an enemy ship
        Instantiate(enemyShip, new Vector2(15, 0), enemyShip.transform.rotation);
        Instantiate(playerProjectile, new Vector2(15, 0), playerProjectile.transform.rotation);

        // tests SpawnManager and makes sure enemies communicate properly with EnemyManager
        spawnManager.SpawnWave();
        enemyManager.EnemiesChangeDirection();

        // forces a game over to check that GameManager can loop back to the menu
        // as a side effect, multiple players are spawned. this is expected behavior
        gameManager.PlayerDied();
        gameManager.PlayerDied();
        gameManager.PlayerDied();
    }

    private void CheckTests()
    {
        checkOnce = false;

        // checks if GameManager starts the game correctly
        if (GameObject.Find("Player(Clone)")) { Debug.Log("Player spawned properly."); }
        else { Debug.Log("Player did not spawn properly."); }

        // checks if enemy collision is working
        if (!GameObject.Find("AlienShip(Clone)")) { Debug.Log("Enemy collision working properly."); }
        else { Debug.Log("Enemy collision is not working properly."); }

        // checks if a new wave was spawned
        if (GameObject.Find("Enemy(Clone)")) { Debug.Log("Enemies spawning properly."); }
        else { Debug.Log("Enemies not spawning properly."); }

    }
}
