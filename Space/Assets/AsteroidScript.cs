using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float rotationSpeed;
    public float minSpeed, maxSpeed;  //зададим числа в диапазоне которых будет находится скорость полета астероида
    public float minSize, maxSize;  //рандомный размер астероида

    float size;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;   //скорость с которой астероид вращается
        float speed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, -speed);  //скорость и заданное направление с которой астероид летит

        size = Random.Range(minSize, maxSize);
        asteroid.transform.localScale *= size;

    }

    //срабатывает в начале столкновения с другим объектом-коллайдером (переменная other)
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Asteroid" || other.tag == "GameBoundary")
        {
            return;
        }
        Destroy(other.gameObject); //уничтожение второго объекта
        Destroy(gameObject);//уничтожение астероида

        GameObject explosion = Instantiate(asteroidExplosion, transform.position, Quaternion.identity);//взрыв астероида при столкновении с чем-угодно

        explosion.transform.localScale *= size;
                
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }
        else
        {
            GameControllerScript.instance.increaseScore(10);
        }

        
    }

}
