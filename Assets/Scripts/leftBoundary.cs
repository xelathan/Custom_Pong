using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftBoundary : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update

    public bool hasEnded = false;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Ball>()) {
            FindObjectOfType<GameManager>().hasStarted = false;
            FindObjectOfType<GameManager>().clicked = false;


            hasEnded = true;
            Destroy(other.gameObject);
            FindObjectOfType<Score>().canvas.enabled = false;
            StartCoroutine(Wait(0.5f));
        }
    }

    IEnumerator Wait(float time) {
        yield return new WaitForSeconds(time);
        FindObjectOfType<Score>().canvas.enabled = false;
        FindObjectOfType<EndMenu>().score.text = "Final Score: " + FindObjectOfType<Score>().GetScore();
        FindObjectOfType<EndMenu>().canvas.enabled = true;
    }

}
