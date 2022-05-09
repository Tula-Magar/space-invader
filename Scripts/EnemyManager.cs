using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private List<GameObject> enemies = new List<GameObject>();
    public GameObject projectile;

    private float timerShoot;
    private float timerRespawn;

    private float TimerIncrease = 3.0f;
    private float substract;
    private Text Level_Reset;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        Level_Reset = GameObject.Find("Canvas/LevelReset/LevelResetText").GetComponent<Text>();
        GameObject.Find("Canvas/LevelReset").GetComponent<Image>().color = new Color(255, 0, 187, 255);
        Level_Reset.text ="LevelReset";
    }

    void Update()
    {
        timerShoot += Time.deltaTime;

        if (enemies.Count == 0)
        {
            timerRespawn += Time.deltaTime;
            if (timerRespawn > PlayerPrefs.GetFloat("LevelReset"))
            {
                Respawn();
            }
        }
        if (PlayerPrefs.GetFloat("LevelReset", 0) == 0)
        {
            PlayerPrefs.DeleteKey("LevelReset");
            if (timerShoot > TimerIncrease && enemies.Count > 0)
            {
                RandomShootOnEqual();
            }
        }
        else
        {
            if (timerShoot > PlayerPrefs.GetFloat("LevelReset") && enemies.Count > 0)
            {
                RandomShootOnLess();
            }
        }
    }

    // modified Observer pattern
    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public void EnemiesChangeDirection()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().ChangeDirection();
        }
    }

    public void Respawn(){
        spawnManager.SpawnWave();
        substract = PlayerPrefs.GetFloat("LevelReset");
        PlayerPrefs.SetFloat("LevelReset", substract - 0.5f); // We can slow down using different number, as for a level up test we gonna use 2.8f
        timerRespawn = 0;
    }

    public void RandomShootOnEqual(){
        int randomEnemy = Random.Range(0, enemies.Count);
        Instantiate(projectile, enemies[randomEnemy].transform.position, projectile.transform.rotation);
        timerShoot = 0;
        PlayerPrefs.SetFloat("LevelReset", TimerIncrease);
        Debug.Log(PlayerPrefs.GetFloat("LevelReset"));
    }
    public void RandomShootOnLess(){
        int randomEnemy = Random.Range(0, enemies.Count);
        Instantiate(projectile, enemies[randomEnemy].transform.position, projectile.transform.rotation);
        timerShoot = 0;
        Debug.Log(PlayerPrefs.GetFloat("LevelReset"));
    }
}

