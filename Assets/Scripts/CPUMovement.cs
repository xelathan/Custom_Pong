using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(FindObjectOfType<GameManager>().hasStarted && FindObjectOfType<leftBoundary>().hasEnded == false) {
            Vector2 currentPosition = rigidbody2D.position;
            currentPosition.y = FindObjectOfType<Ball>().GetRigidbody().position.y;
            rigidbody2D.position = currentPosition;
        }
    }
}
