using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    private float timer;
    public float setTimer;
    public Text textField;
    public Text title;
    // Start is called before the first frame update
    void Start()
    {
        timer = setTimer;
        Debug.Log(textField.text);
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<GameManager>().clicked == false) {
            timer = timer - Time.deltaTime;
            if(timer < 0 && textField.text == "Tap anywhere to begin...") {
                textField.text = "";
                timer = setTimer;
            }
            if(timer < 0 && textField.text == "") {
                textField.text = "Tap anywhere to begin...";
                timer = setTimer;
            }
        } else if (FindObjectOfType<GameManager>().clicked == true){
            textField.text = "Tap anywhere to begin...";
            float newAlphaTitle = title.color.a;
            newAlphaTitle -= Time.deltaTime;
            title.color = new UnityEngine.Color(title.color.r, title.color.g, title.color.b, newAlphaTitle);

            float newAlphaTextField = textField.color.a;
            newAlphaTextField -= Time.deltaTime;
            textField.color = new UnityEngine.Color(textField.color.r, textField.color.g, textField.color.b, newAlphaTextField);

        }

    }
}
