using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy_Bomb;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    
    float nextSpawn = 0.0f;

    float currentSpeed = 0f;
    float targetSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Accelerate());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (spawnRate < 0 )
        {
            spawnRate = Mathf.Abs(spawnRate);
        }
        else if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-13f, 13f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy_Bomb, whereToSpawn, Quaternion.identity); 
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
            yield return new WaitForSeconds(5f);
            spawnRate = spawnRate - 0.3f;
            
            Debug.Log("5 sec past and spawnRate is "+ spawnRate);           
        }
    }  
}


