using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayerScript : MonoBehaviour
{
    public float speed;

    public float tiltX, tiltZ; //коэффициент наклона
    
    public float xMin, xMax, zMin, zMax;  //переменные которые ограничивают наши границы

    public GameObject lazerShot; //GameObject дает возможность положить туда игровой объект
    public Transform laserGun; // Transform позволяет задать место откуда мы будем стрелять

    public float shotDelay; //как часто можно стрелять
    public GameObject asteroidExplosion;

    float nextShotTime;

    Rigidbody playerShip;

    // Start is called before the first frame update
    void Start() 
    {//код выполняется при создании объекта и добавлении его на сцену
        playerShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {//выполняется на каждый кадр (fps)
        //влево или вправо
        //вверх или вниз
        if (!GameControllerScript.instance.getIsStarted())
        {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");   //-1(лево), +1(вправо), функция Input.GetAxis возвращает любое число от -1 до +1 и мы сохраняем это число в переменную moveHorizontal
        float moveVertical = Input.GetAxis("Vertical");       //-1(вниз), +1(вверх)
        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;  //вектора по которым корабль двигается 

        float restrictedX = Mathf.Clamp(playerShip.position.x, xMin, xMax);//ограничивает значение переменных между переданным минимумом и максимумом 
        float restrictedZ = Mathf.Clamp(playerShip.position.z, zMin, zMax);
        playerShip.position = new Vector3(restrictedX, 0, restrictedZ);

        playerShip.rotation = Quaternion.Euler(tiltZ * playerShip.velocity.z, 0, -playerShip.velocity.x * tiltX); //наклон в зависимости он полета 

        //создание лазерного выстрела
        
        if (Time.time > nextShotTime && Input.GetButton("Fire1")) //событие по кнопошке, Fire1 такая логическая кнопка которая установлена по умолчанию как атака
        {
            Instantiate(lazerShot, laserGun.position, Quaternion.identity); //Instantiate-создать, первый параметр - что создать?, второй - где создать?, Quaternion.identity пустой поворот лазера
            nextShotTime = Time.time + shotDelay;
        }

        if (Input.GetButton("Fire2"))
        {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach(GameObject asteroid in asteroids)
            {
                Destroy(asteroid);
                Instantiate(asteroidExplosion, asteroid.transform.position, Quaternion.identity);
            }
        }
    }
}
