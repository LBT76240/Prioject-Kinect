using UnityEngine;
using System.Collections;

public class EstSelectionnableMVS : MonoBehaviour {

    public GameObject right_hand;
    public Material material;
    public float erreur;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(pasloin(erreur)) {
            Color color = material.color;
            color.r = 1;
            material.color = color;
            print("Proche");
        } else {
            Color color = material.color;
            color.r = 0;
            material.color = color;
            print("Loin");
        }
	}

    bool pasloin(float erreur) {
        float distance = Mathf.Pow(right_hand.transform.position.x - transform.position.x,2) + Mathf.Pow(right_hand.transform.position.y - transform.position.y,2);
        return distance < erreur;
        
    }
}
