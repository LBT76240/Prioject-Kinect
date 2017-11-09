using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExemplaUseOfMillitaryPose : MonoBehaviour {

    public MillitaryPose millitaryPose;
    public Text text;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        bool gestureDetected = millitaryPose.getGestureDetected();
        if (gestureDetected) {

            text.color = Color.green;
        } else {

            text.color = Color.red;
        }
    }
}
