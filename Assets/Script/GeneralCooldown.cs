using UnityEngine;
using System.Collections;

public class GeneralCooldown : MonoBehaviour {


    bool isOnCooldown;
    float timer;
    public float timerLimit = 1f; 

    public bool getIsOnCooldown() {
        return isOnCooldown;
    }

    public void setIsOnCooldown() {
        isOnCooldown = true;
        timer = 0f;
    }

    // Use this for initialization
    void Start () {
        isOnCooldown = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(isOnCooldown) {
            timer += Time.deltaTime;
            if(timer> timerLimit) {
                isOnCooldown = false;
            }
        }
	}
}
