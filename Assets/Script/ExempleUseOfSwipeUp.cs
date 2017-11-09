using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExempleUseOfSwipeUp : MonoBehaviour {

    public SwipingUpWithBothHands swipingUpWithBothHands;

    public Text text;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        bool gestureDetected = swipingUpWithBothHands.getGestureDetected();
        if (gestureDetected) {

            text.color = Color.green;
        } else {

            text.color = Color.red;
        }

    }
}
