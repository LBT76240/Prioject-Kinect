using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExempleUseOfPunch : MonoBehaviour {

    public RunAndPunch runAndPunch;
    public Text text;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        bool gestureDetected = runAndPunch.getGestureDetectedPunch();
        if (gestureDetected) {

            text.color = Color.green;
        } else {

            text.color = Color.red;
        }
    }
}
