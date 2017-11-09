using UnityEngine;
using System.Collections;

public enum LastDetected {
    Nothing,
    Right,
    Left
};

public class RunAndPunch : MonoBehaviour {

    public GeneralCooldown generalCooldown;

    public GameObject Wrist_Right;
    public GameObject Wrist_Left;
    public GameObject Hip_Right;
    public GameObject Hip_Left;

    float[] posZLeft;
    float[] posZRight;
    float[] difPosZLeft;
    float[] difPosZRight;

    int index;

    public int minTimeBetweenHands;
    public int maxTimeBetweenHands;

    public int tailleTab = 30;
    public int tailleTabPunch = 10;

    bool detectionReady;

    bool gestureDetectedRun;
    bool gestureDetectedPunch;

    

    float timer;
    public float timerLimit = 0.1f;

    float timerCooldown;
    public float timerCooldownLimit = 1f;
    public float timerCooldownLimitRun = 2f;

    public float seuilDetection = 3f;
    public float seuilDetectionPunch = 4f;

    public float seuilZoneMorte = 0.5f;


    public bool getGestureDetectedPunch() {
        return gestureDetectedPunch;
    }

    public bool getGestureDetectedRun() {
        return gestureDetectedRun;
    }

    void addValue(float newPosZLeft, float newPosZRight) {


        posZLeft[index] = newPosZLeft;
        posZRight[index] = newPosZRight;


        if (index != 0) {
            difPosZLeft[index] = (posZLeft[index] - posZLeft[index - 1]);
            difPosZRight[index] = (posZRight[index] - posZRight[index - 1]);
        } else {
            difPosZLeft[index] = (posZLeft[index] - posZLeft[tailleTab - 1]);
            difPosZRight[index] = (posZRight[index] - posZRight[tailleTab - 1]);

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


        int numberRight = 0;
        int numberLeft = 0;
        LastDetected lastDetected = LastDetected.Nothing;

        int indexLast = 0;

        bool toFront = false;
        bool punch = false;
        bool leftMove = false;

        for (int i = 0; i < tailleTab; i++) {
            diffLeft = diffLeft + difPosZLeft[(tailleTab + index - 1 - i) % tailleTab];
            diffRight = diffRight + difPosZRight[(tailleTab + index - 1 - i) % tailleTab];




            if (diffLeft < -seuilDetection && diffRight > seuilDetection) {
                if((lastDetected == LastDetected.Nothing || lastDetected == LastDetected.Left) && (i-indexLast)>= minTimeBetweenHands && (i - indexLast) <= maxTimeBetweenHands) {
                    indexLast = i;
                    numberRight++;
                    lastDetected= LastDetected.Right;
                }
            } else if (diffRight < -seuilDetection && diffLeft > seuilDetection) {
                if((lastDetected == LastDetected.Nothing || lastDetected == LastDetected.Right) && (i - indexLast) >= minTimeBetweenHands && (i - indexLast) <= maxTimeBetweenHands) {
                    indexLast = i;
                    numberLeft++;
                    lastDetected = LastDetected.Left;
                }
            }

            if(i<tailleTabPunch) {
                if(diffLeft > seuilZoneMorte || diffLeft < -seuilZoneMorte) {
                    leftMove = true;
                }

                if(!toFront) {
                    if (diffRight < -seuilDetectionPunch) {
                        toFront = true;
                    }
                } else if (diffRight < seuilZoneMorte && diffRight >-seuilZoneMorte) {
                    punch = true;
                }
                

            }

            
        }



        


        if (numberRight > 1 && numberLeft > 1) {
            print("RUN");
            gestureDetectedRun = true;
            timerCooldown = 0f;
            generalCooldown.setIsOnCooldown();
        } else if(punch && !leftMove) {
            print("PUNCH");
            gestureDetectedPunch = true;
            timerCooldown = 0f;
            generalCooldown.setIsOnCooldown();
        }
       

    }

    // Use this for initialization
    void Start () {
        index = 0;

        posZLeft = new float[tailleTab];
        posZRight = new float[tailleTab];
        difPosZLeft = new float[tailleTab];
        difPosZRight = new float[tailleTab];


        detectionReady = false;
        gestureDetectedRun = false;
        gestureDetectedPunch = false;
       

        timer = 0f;
        timerCooldown = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        timer = timer + Time.deltaTime;
        timerCooldown = timerCooldown + Time.deltaTime;


        if (timer > timerLimit) {
            timer = timer - timerLimit;
            float valueLeft;
            float valueRight;

            valueLeft = Wrist_Left.transform.position.z;
            valueRight = Wrist_Right.transform.position.z;





            addValue(valueLeft, valueRight);

            if (detectionReady && !generalCooldown.getIsOnCooldown()) {
                detecteGesture();
            }
            




        }


        if (gestureDetectedRun) {
            if (timerCooldown > timerCooldownLimitRun) {
                gestureDetectedRun = false;
                

            }
        }
        if ( gestureDetectedPunch) {
            if (timerCooldown > timerCooldownLimit) {
                
                gestureDetectedPunch = false;

            }
        }

        
    }
}
