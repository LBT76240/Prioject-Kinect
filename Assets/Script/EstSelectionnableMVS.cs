using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EstSelectionnableMVS : MonoBehaviour {

    public GameObject right_hand;
    public Material material;
    public Text text;
    public Slider slider;
    public float erreur;
    public float timer;
    public float timerLimit = 3f;
    public string button;
    public GameObject canvasDetection;
    bool buttonOn;

	// Use this for initialization
	void Start () {
        timer = 0f;
        buttonOn = false;
        if (button == "detection") {
            canvasDetection.SetActive(false);
            text.text = "Start Detection";
        }
        if (button == "exit") {
            text.text = "ExitGame";
            
        }
    }
	
    public void returnMenu() {
        if (buttonOn) {
            canvasDetection.SetActive(false);
            text.text = "Start Detection";
            buttonOn = false;
            
        }
    }

    void buttonClick() {
        if (button == "detection") {
            if (buttonOn) {
                canvasDetection.SetActive(false);
                text.text = "Start Detection";
                buttonOn = false;
            } else {
                canvasDetection.SetActive(true);
                text.text = "Exit Detection";
                buttonOn = true;
            }
        }
        if (button == "exit") {
            Application.Quit();
        }
    }

	// Update is called once per frame
	void Update () {
	    if(pasloin(erreur)) {
            
            
            timer += Time.deltaTime;
            if(timer> timerLimit) {
                timer = timerLimit;
                buttonClick();

                timer = 0;
            }
        } else {
 
            
            timer -= Time.deltaTime;
            if (timer < 0f) {
                timer = 0f;
            }
        }
        Color color = material.color;
        color.g = timer / timerLimit;
        color.r = 1-timer / timerLimit;
        material.color = color;
        slider.value= timer / timerLimit;

        if(Input.GetButtonDown("Cancel")) {
            if (button == "detection" && buttonOn) {
                buttonClick();
            }
            
        }

        if(Input.GetButtonDown("Submit")) {
            
            if (button == "exit") {
                buttonClick();
            }
        }

        if (Input.GetButtonDown("Jump")) {
            if (button == "detection" && !buttonOn) {
                buttonClick();
            }
        }
    }

    bool pasloin(float erreur) {
        float distance = Mathf.Pow(right_hand.transform.position.x - transform.position.x,2) + Mathf.Pow(right_hand.transform.position.y - transform.position.y,2);
        return distance < erreur;
        
    }
}
