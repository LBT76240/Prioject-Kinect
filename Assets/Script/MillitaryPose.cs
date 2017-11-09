using UnityEngine;
using System.Collections;

public class MillitaryPose : MonoBehaviour {

    public GameObject head;
    public GameObject hand_right;
    public GameObject elbow_right;
    public GameObject shoulder_right;

    public float seuilDetection = 0.5f;


    bool gestureDetected;


    void detecteGesture() {

        bool head_hand = false;
        bool elbow_shoulder = false;

        float head_hand_X = head.transform.position.x - hand_right.transform.position.x;
        float head_hand_Y = head.transform.position.y - hand_right.transform.position.y;
        float head_hand_Z = head.transform.position.z - hand_right.transform.position.z;

        float elbow_shoulder_X = elbow_right.transform.position.x - shoulder_right.transform.position.x;
        float elbow_shoulder_Y = elbow_right.transform.position.y - shoulder_right.transform.position.y;
        float elbow_shoulder_Z = elbow_right.transform.position.z - shoulder_right.transform.position.z;

        if (head_hand_X < seuilDetection && head_hand_X > -seuilDetection && head_hand_Y < seuilDetection && head_hand_Y > -seuilDetection && head_hand_Z < seuilDetection && head_hand_Z > -seuilDetection) {
            
            head_hand = true;
        }

        if (elbow_shoulder_Y < seuilDetection && elbow_shoulder_Y > -seuilDetection && elbow_shoulder_Z < seuilDetection && elbow_shoulder_Z > -seuilDetection) {
            elbow_shoulder = true;
        }

        if(head_hand && elbow_shoulder) {
            gestureDetected = true;
        } else {
            gestureDetected = false;
        }

    }

    public bool getGestureDetected() {
        return gestureDetected;
    }

    // Use this for initialization
    void Start () {
        gestureDetected = false;

    }
	
	// Update is called once per frame
	void Update () {
        detecteGesture();
	}
}
