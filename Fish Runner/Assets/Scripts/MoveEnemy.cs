using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector2 dir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed, Space.World);
        if (gameObject.transform.position.x < -10) 
        {
            Destroy(gameObject);
        }
    }
}
