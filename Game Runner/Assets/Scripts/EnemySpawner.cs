using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy_Let;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 3f;

    float nextSpawn = 0.0f;

    float currentSpeed = 0f;
    float targetSpeed = 30f;

    void Start()
    {
        StartCoroutine(Accelerate());
    }
    
    void Update()
    {
        if (spawnRate < 0)
        {
            spawnRate = Mathf.Abs(spawnRate);
        }
        else if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(0f, 8f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy_Let, whereToSpawn, Quaternion.identity);
        }

        if (currentSpeed < targetSpeed)
        {
            currentSpeed += Time.deltaTime;
        }
    }

    IEnumerator Accelerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);
            spawnRate = spawnRate - 0.1f;
            
            Debug.Log("8 sec past and spawnRate is "+ spawnRate);           
        }
    }  

    //static spawn with preassigned time
    /*public Transform spawnPos;
    public GameObject Enemy;
    public float time;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Repeat()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(time);
        Instantiate(Enemy, spawnPos.position, Quaternion.identity);
        Repeat();
    }*/
}
