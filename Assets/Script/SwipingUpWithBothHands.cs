using UnityEngine;
using System.Collections;



public class SwipingUpWithBothHands : MonoBehaviour {

    public GeneralCooldown generalCooldown;
    public GameObject Wrist_Right;
    public GameObject Wrist_Left;
    public GameObject Shoulder_Right;
    public GameObject Shoulder_Left;






    float[] posYLeft;
    float[] posYRight;
    float[] difPosYLeft;
    float[] difPosYRight;

    int index;

    public int tailleTab = 10;

    bool detectionReady;

    bool gestureDetected;
    

    float timer;
    public float timerLimit = 0.1f;

    float timerCooldown;
    public float timerCooldownLimit = 1f;

    public float seuilDetection = 0.4f;
    
    public float seuilZoneMorte = 0.1f;

    public bool getGestureDetected() {
        return gestureDetected;
    }

    

    void addValue(float newPosYLeft,float newPosYRight) {
        

        posYLeft[index] = newPosYLeft;
        posYRight[index] = newPosYRight;

        
        if (index != 0) {
            difPosYLeft[index] = (posYLeft[index] - posYLeft[index - 1]);
            difPosYRight[index] = (posYRight[index] - posYRight[index - 1]);
        } else {
            difPosYLeft[index] = (posYLeft[index] - posYLeft[tailleTab - 1]);
            difPosYRight[index] = (posYRight[index] - posYRight[tailleTab - 1]);

        }
        index++;
        if (index == tailleTab) {
            detectionReady = true;
            index = 0;
        }

    }

    void detecteGesture() {
        
        float diffLeft = 0;
        float diffRight = 0;


        bool toUp = false;
        

        for (int i = 0; i < tailleTab; i++) {
            diffLeft = diffLeft + difPosYLeft[(tailleTab + index - 1 - i) % tailleTab];
            diffRight = diffRight + difPosYRight[(tailleTab + index - 1 - i) % tailleTab];

            if (!toUp) {
                
                if (diffLeft < -seuilDetection && diffRight < -seuilDetection 
                    && Shoulder_Right.transform.position.y < posYRight[(tailleTab + index - 1 - i) % tailleTab]
                    && Shoulder_Left.transform.position.y < posYLeft[(tailleTab + index - 1 - i) % tailleTab]) {
                    
                    toUp = true;
                }
            } else {
                
                if (diffLeft < seuilZoneMorte && diffLeft > -seuilZoneMorte && diffRight < seuilZoneMorte && diffRight > -seuilZoneMorte) {
                   
                    print("MovementToUp");
                    gestureDetected = true;
                    timerCooldown = 0f;
                    i = tailleTab;
                    generalCooldown.setIsOnCooldown();

                }
            }
        }
    }


    // Use this for initialization
    void Start() {
        index = 0;

        posYLeft = new float[tailleTab];
        posYRight = new float[tailleTab];
        difPosYLeft = new float[tailleTab];
        difPosYRight = new float[tailleTab];

        
        detectionReady = false;
        gestureDetected = false;
        
        timer = 0f;
        timerCooldown = 0f;
    }

    // Update is called once per frame
    void Update() {

        timer = timer + Time.deltaTime;
        timerCooldown = timerCooldown + Time.deltaTime;


        if (timer > timerLimit) {
            timer = timer - timerLimit;
            float valueLeft;
            float valueRight;

            valueLeft = Wrist_Left.transform.position.y;
            valueRight = Wrist_Right.transform.position.y;

            

            

            addValue(valueLeft, valueRight);
            if (!gestureDetected && detectionReady && !generalCooldown.getIsOnCooldown()) {
                detecteGesture();
            }

            


        }

        if (gestureDetected) {
            if (timerCooldown > timerCooldownLimit) {
                gestureDetected = false;
                
            }
        }


    }
}
