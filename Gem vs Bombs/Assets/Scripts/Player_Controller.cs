using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    private Vector3 mousePosition;
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed_mouse = 50f;
    private float moveSpeed_finger = 5f;
    [SerializeField] public GameObject gameOverUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
          
    void Update()
    {
        gameOverUI.SetActive(false);
        //Follow Mouse Pointer
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x , 0)* moveSpeed_mouse;  //or.. direction.y ..+ freeze position by y
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
        //Follow Finger Pointer
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, 0) * moveSpeed_finger;  //or.. direction.y ..+ freeze position by y

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
        

        //boundary
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12f, 12f), Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }


    /*the gem will have several lives in the future*/

    /*private static int _remainingLives = 1;
    public static int RemainingLives
    {
        get { return _remainingLives; }
    }*/
          
    //destroy objects  
    private void OnCollisionEnter2D(Collision2D collider)
    {
        Destroy(gameObject);    //destroy player 
        //Destroy(collider.gameObject); //destroy enemy       
        
        EndGame();        
    }

    //Game over ui 
    public void EndGame()
    {       
        Debug.Log("End Game lol");
        gameOverUI.SetActive(true);
    }
}

