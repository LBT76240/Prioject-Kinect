using UnityEngine;
using System.Collections;

public class MoveFromKeyboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1")) {
            Vector3 pos= transform.position;
            pos.x +=0.2f;
            transform.position = pos;
        }
	}
}
