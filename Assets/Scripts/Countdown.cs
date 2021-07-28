using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Canvas canvas;
    public Text self;
    float startingTime = 3f;
    float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canvas.enabled == true) {
            currentTime -= 1 * Time.deltaTime;
            float roundedTime = 0f;
            if (currentTime <= 3f && currentTime > 2f) {
                roundedTime = 3f;
            } else if(currentTime <= 2f && currentTime > 1f) {
                roundedTime = 2f;
            } else if(currentTime <= 1f && currentTime > 0f) {
                roundedTime = 1f;
            }
            
            if (currentTime > 0) {
                self.text = roundedTime.ToString();
            } else {
                self.text = "Go!";
                StartCoroutine(delayTime(1f));
            }
        }

    }

    IEnumerator delayTime(float time) {
        yield return new WaitForSeconds(time);
        canvas.enabled = false;
        currentTime = startingTime;
        FindObjectOfType<Score>().canvas.enabled = true;
    }


}
