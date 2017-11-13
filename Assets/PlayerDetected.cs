using UnityEngine;
using System.Collections;
using Kinect;
using UnityEngine.UI;

public class PlayerDetected : MonoBehaviour {
    public DeviceOrEmulator devOrEmu;
    private Kinect.KinectInterface kinect;
    public Text text;
    bool lastPlayerDetected;
    // Use this for initialization
    void Start () {
        kinect = devOrEmu.getKinect();
        lastPlayerDetected = false;
        text.text = "No Player Detected";
        text.color = Color.red;
    }
	
    void changeDetection (bool value) {
        if (value != lastPlayerDetected) {
            
            if (value) {
                text.text = "Player Detected";
                text.color = Color.green;
            } else {
                text.text = "No Player Detected";
                text.color = Color.red;
            }
            lastPlayerDetected = value;
        } 
    }

	// Update is called once per frame
	void Update () {
        bool playerDetected = false;
        for (int ii = 0; ii < Kinect.Constants.NuiSkeletonCount; ii++) {
            if(kinect.getSkeleton().SkeletonData[ii].eTrackingState == Kinect.NuiSkeletonTrackingState.SkeletonTracked) {
                playerDetected = true;
            }
        }
        
        changeDetection(playerDetected);

    }
}
