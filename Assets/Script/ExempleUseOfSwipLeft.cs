using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExempleUseOfSwipLeft : MonoBehaviour {

    public SwipingWithRightHand swipingWithRightHand;

    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool gestureDetected = swipingWithRightHand.getGestureDetectedToLeft();
        if(gestureDetected) {
            
            text.color = Color.green;
        } else {
            
            text.color = Color.red;
        }

    }
}
