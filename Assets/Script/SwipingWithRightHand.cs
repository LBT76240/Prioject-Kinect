using UnityEngine;
using System.Collections;



public class SwipingWithRightHand : MonoBehaviour {

    public GeneralCooldown generalCooldown;
    public GameObject Wrist_Right;
    public GameObject Shoulder_Right;
 





    float [] posX ;
    float [] difPosX;

    int index;
    
    public int tailleTab = 10;

    bool detectionReady;

    bool gestureDetectedToRight;
    bool gestureDetectedToLeft;

    float timer;
    public float timerLimit=0.1f;

    float timerCooldown;
    public float timerCooldownLimit = 1f;

    public float seuilDetectionRight = 3f;
    public float seuilDetectionLeft = 3f;
    public float seuilZoneMorte = 0.5f;

    public bool getGestureDetectedToRight () {
        return gestureDetectedToRight;
    }

    public bool getGestureDetectedToLeft (){
        return gestureDetectedToLeft;
    }

    void addValue(float newRotate) {
        posX[index] = newRotate;
        if (index != 0) { 
            difPosX[index] = (posX[index] - posX[index - 1]);
        } else {
            difPosX[index] = (posX[index] - posX[tailleTab-1]);
        }
        index++;
        if(index== tailleTab) {
            detectionReady = true;
            index = 0;
        }
        
    }

    void detecteToTheRight() {
        float diff = 0;

        bool toRight = false;
        bool toLeft = false;

        for(int i =0;i<tailleTab;i++) {
            diff = diff + difPosX[(tailleTab+ index - 1-i)%tailleTab];
            if (!toRight && !toLeft) {
                if (diff < -seuilDetectionRight 
                    && Shoulder_Right.transform.position.y > posX[(tailleTab + index - 1 - i) % tailleTab]) {
                    //print("toLeft");
                    toLeft = true;
                }
                if (diff > seuilDetectionLeft
                    && Shoulder_Right.transform.position.y > posX[(tailleTab + index - 1 - i) % tailleTab]) {
                    //print("toRight");
                    toRight = true;
                }
            } else {
                if (diff < seuilZoneMorte && diff > -seuilZoneMorte
                    && Shoulder_Right.transform.position.y > posX[(tailleTab + index - 1 - i) % tailleTab]) {
                    if(toRight) {
                        print("MovementToLeft");
                        gestureDetectedToLeft = true;
                        timerCooldown = 0f;
                        i = tailleTab;
                        generalCooldown.setIsOnCooldown();
                    } else {
                        print("MovementToRight");
                        gestureDetectedToRight = true;
                        timerCooldown = 0f;
                        i = tailleTab;
                        generalCooldown.setIsOnCooldown();
                    }
                    
                }
            }
        }
    }


    // Use this for initialization
    void Start () {
        index = 0;
        posX = new float[tailleTab];
        difPosX = new float[tailleTab];
        detectionReady = false;
        gestureDetectedToRight = false;
        gestureDetectedToLeft = false;
        timer = 0f;
        timerCooldown = 0f;
    }
	
	// Update is called once per frame
	void Update () {

        timer = timer+Time.deltaTime;
        timerCooldown = timerCooldown + Time.deltaTime;


        if (timer> timerLimit) {
            timer = timer - timerLimit;
            float value;
            
            value = Wrist_Right.transform.position.x;
            addValue(value);
            if(!gestureDetectedToRight && !gestureDetectedToLeft && detectionReady && !generalCooldown.getIsOnCooldown()) {
                detecteToTheRight();
            }
           
        }

        if(gestureDetectedToRight || gestureDetectedToLeft ) {
            if(timerCooldown > timerCooldownLimit) {
                gestureDetectedToRight = false;
                gestureDetectedToLeft = false;
            }
        }

        
	}
}
