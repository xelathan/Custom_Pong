using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Camera
    private Camera mainCamera;

    //Boundaries
    public BoxCollider2D leftBound;
    public BoxCollider2D rightBound;
    public BoxCollider2D topBound;
    public BoxCollider2D bottomBound;

    public Transform backgroundTransform;
    public Transform playerTransform;
    
    public bool hasStarted = false;

    public GameObject ball;

    public int count = 0;

    public bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        leftBound.size = new Vector2(1f, Screen.height);
        leftBound.offset =  new Vector2(-mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 0.3f, 0f);

        rightBound.size = new Vector2(1f, Screen.height);
        rightBound.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - 0.3f, 0f);

        topBound.size = new Vector2(Screen.width, 1f);
        topBound.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);

        bottomBound.size = new Vector2(Screen.width, 1f);
        bottomBound.offset = new Vector2(0f, -mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);

        backgroundTransform.localScale = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x, mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);

        if(Input.GetButtonDown("Fire1") && hasStarted == false && count == 0 && clicked == false) {
            clicked = true;
            InvokeCoroutine();
            count = 1;
        }
    }

    public IEnumerator StartGame(float time) {
        yield return new WaitForSeconds(time);
        FindObjectOfType<leftBoundary>().hasEnded = false;
        FindObjectOfType<Score>().ResetScore();
        FindObjectOfType<PlayerController>().GetRigidbody().position = new Vector2(FindObjectOfType<PlayerController>().GetRigidbody().position.x, 0f);
        GameObject myball = Instantiate(ball, new Vector3(0f, 0f, 0f), Quaternion.identity);

        myball.GetComponent<Ball>().FireBall();
        hasStarted = true;
        Destroy(GameObject.Find("BeginMenu"));
    }

    public void QuitGame() {
        Debug.Log("End game");
        Application.Quit();
    }


    public void InvokeCoroutine() {
        StartCoroutine(StartGame(1.5f));
    }

    public void ResetCountDown() {
        FindObjectOfType<Countdown>().self.text = "";
        
    }

}
