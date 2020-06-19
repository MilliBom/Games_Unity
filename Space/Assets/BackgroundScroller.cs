using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed;
    Vector3 startPosition;//стартовая позиция
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;//указывает на позицию текущего объекта
    }

    // Update is called once per frame
    void Update()
    {
        float move = Mathf.Repeat(Time.time * speed, 320);  //всегда вернет значение от 0 до 160, растет с течением времени в зависимости от speed

        transform.position = startPosition + new Vector3(0, 0, -move);
    }
}
