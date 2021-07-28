using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    float vertical;
    private float moveSpeed;
    public float axis;
    public bool isAPlayer;

    void Start()
    {
     rigidbody2D = GetComponent<Rigidbody2D>();
     moveSpeed = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isAPlayer) {
            vertical = Input.GetAxis("Vertical");
        }

    }

    void FixedUpdate() {
        if (FindObjectOfType<GameManager>().hasStarted == false || FindObjectOfType<leftBoundary>().hasEnded == true) {
            moveSpeed = 0;
        } else {
            moveSpeed = 10;
        }
        Vector2 currentPosition = rigidbody2D.position;
        if (isAPlayer) {
            currentPosition.y = currentPosition.y + moveSpeed * vertical * Time.deltaTime;
        }
        currentPosition.x = axis * Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + -axis;
        rigidbody2D.position = currentPosition;


    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Ball>() != null && vertical > 0) {
            Debug.Log(other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.x);
            if(isAPlayer) {
                other.gameObject.GetComponent<Ball>().GetRigidbody().velocity = new Vector2(other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.x + 0.5f,Mathf.Abs(other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.y));
                other.gameObject.GetComponent<Ball>().GetRigidbody().AddForce(new Vector2(0f, 50f));
            } else {
                other.gameObject.GetComponent<Ball>().GetRigidbody().velocity = new Vector2(other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.x ,Mathf.Abs(other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.y));
            }
        } else if(other.gameObject.GetComponent<Ball>() != null && vertical < 0) {
            float newValue = 0;
            if(other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.y < 0) {
                newValue = other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.y;
            } else {
                newValue = -other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.y;
            }
            if(isAPlayer) {
                other.gameObject.GetComponent<Ball>().GetRigidbody().velocity = new Vector2(other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.x + 0.5f, newValue);
                other.gameObject.GetComponent<Ball>().GetRigidbody().AddForce(new Vector2(0f, -50f));
            } else {
                other.gameObject.GetComponent<Ball>().GetRigidbody().velocity = new Vector2(other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.x , newValue);
            }
        }

        if(other.gameObject.GetComponent<Ball>() != null && vertical > 0) {
            float tryTest = other.gameObject.GetComponent<Ball>().GetRigidbody().velocity.x;
            if(tryTest < 7) {
                other.gameObject.GetComponent<Ball>().GetRigidbody().AddForce(new Vector2(400f, 0f));
            }
        }

        if(other.gameObject.GetComponent<Ball>() != null && isAPlayer) {
            FindObjectOfType<Score>().ChangeScore(1);
        }

    }

    public Rigidbody2D GetRigidbody() {
        return rigidbody2D;
    }

}
