using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float randomNumber;


    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        randomNumber = Random.Range(0f, 1f);
    }
  

    // Update is called once per frame
    void Update()
    {
    }

    public void FireBall() {
        FindObjectOfType<Countdown>().canvas.enabled = true;
        
        StartCoroutine(delayStart(3.5f));
    }

    public Rigidbody2D GetRigidbody() {
        return rigidbody2D;
    }

    private IEnumerator delayStart(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        rigidbody2D.gravityScale = 0;
        if(randomNumber <= 0.25f) {
            rigidbody2D.AddForce(new Vector2(400, 200f));
        } else if (randomNumber <= 0.5f){
            rigidbody2D.AddForce(new Vector2(-400, -200f));
        } else if(randomNumber <= 0.75f) {
            rigidbody2D.AddForce(new Vector2(400, -200f));
        } else {
            rigidbody2D.AddForce(new Vector2(-400, 200f));
        }
    }
}
