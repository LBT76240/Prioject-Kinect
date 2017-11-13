using UnityEngine;
using System.Collections;

public class DebugSouris : MonoBehaviour {
    public GameObject right_hand;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Input.mousePosition;
        pos.z = right_hand.transform.position.z;
        
        

        right_hand.transform.position = pos;

    }
}
