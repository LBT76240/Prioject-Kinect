using UnityEngine;
using System.Collections;

public class avance : MonoBehaviour {

    public Transform rightColarTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(rightColarTransform.rotation.z>-30 && rightColarTransform.rotation.z < 30) {
            avancer();
        }

	}

    void avancer () {
        Vector3 pos = transform.position;
        pos.z += Time.deltaTime;
        transform.position = pos;
    }
}
