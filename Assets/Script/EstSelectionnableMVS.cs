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
    public string sceneToLoad;
    public GameObject canvasDetection;
    bool detectionOn;

	// Use this for initialization
	void Start () {
        timer = 0f;
        detectionOn = false;
        canvasDetection.SetActive(false);
        text.text = "Start Detection";
    }
	
	// Update is called once per frame
	void Update () {
	    if(pasloin(erreur)) {
            
            
            timer += Time.deltaTime;
            if(timer> timerLimit) {
                timer = timerLimit;
                
                if(detectionOn) {
                    canvasDetection.SetActive(false);
                    text.text = "Start Detection";
                    detectionOn = false;
                } else {
                    canvasDetection.SetActive(true);
                    text.text = "Exit Detection";
                    detectionOn = true;
                }
                
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

        if(Input.GetButton("Cancel")) {
            if (detectionOn) {
                canvasDetection.SetActive(false);
                text.text = "Start Detection";
                detectionOn = false;
            } else {
                canvasDetection.SetActive(true);
                text.text = "Exit Detection";
                detectionOn = true;
            }
        }
    }

    bool pasloin(float erreur) {
        float distance = Mathf.Pow(right_hand.transform.position.x - transform.position.x,2) + Mathf.Pow(right_hand.transform.position.y - transform.position.y,2);
        return distance < erreur;
        
    }
}
