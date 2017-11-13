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

	// Use this for initialization
	void Start () {
        timer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
	    if(pasloin(erreur)) {
            
            print("Proche");
            timer += Time.deltaTime;
            if(timer> timerLimit) {
                timer = timerLimit;
                Application.LoadLevel(sceneToLoad);
            }
        } else {
 
            print("Loin");
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
    }

    bool pasloin(float erreur) {
        float distance = Mathf.Pow(right_hand.transform.position.x - transform.position.x,2) + Mathf.Pow(right_hand.transform.position.y - transform.position.y,2);
        return distance < erreur;
        
    }
}
