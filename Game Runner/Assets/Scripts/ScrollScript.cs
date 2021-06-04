using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed = 5f;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*scrollSpeed*Time.deltaTime);
        if(transform.position.x< -35.38f)
        {
            transform.position = startPos;
        }
    }
}
