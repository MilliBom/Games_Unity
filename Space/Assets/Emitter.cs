using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay; //задержка между спавнамии астероида
    float nextLaunchTime;//dhtvz ytrcn pfgecrf
    
    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.instance.getIsStarted())
        {
            return;
        }
        float positionZ = transform.position.z; //оставляет Emitter за камерой, т.е. там где он находится
        float positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2); //спавн астероидов в диапазоне деленном на 2

        if(Time.time > nextLaunchTime)
        {
            Instantiate(asteroid, new Vector3(positionX, 0, positionZ), Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
        
        
    } 
}
