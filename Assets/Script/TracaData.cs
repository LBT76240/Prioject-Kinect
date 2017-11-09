using UnityEngine;
using System.Collections;
using System.IO;

public class TracaData : MonoBehaviour {

    public string fileName;
    StreamWriter writer;
    public KinectPointController kinectPointController;
    int i = 0;
    float time = 0f;
    
    // Use this for initialization
    void Start () {

        writer = new StreamWriter("C:\\Users\\trail\\Desktop\\"+ fileName);
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        
        time += Time.deltaTime;
        
        writer.WriteLine(i + " : " + time);
        writer.WriteLine("X : " + pos.x + "; Y : " + pos.y + "; Z : " + pos.z + ";");
        writer.WriteLine("Wr : " + rot.w + "; Xr : " + rot.x + "; Yr : " + rot.y + "; Zr : " + rot.z + ";");

        i++;
       
    }

    void OnDestroy() {
        writer.Close();
    }


}
