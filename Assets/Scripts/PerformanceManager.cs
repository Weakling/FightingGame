using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceManager : MonoBehaviour {


    public int target = 60;
    private float testTime = 0;//0.01666667f;

    private void Awake()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;
    }

    // Use this for initialization
    void Start () {
		
	}


    private void FixedUpdate()
    {
        /*testTime += 0.01667f;
        if(testTime >= 1.0f)
        {
            print(testTime);
            testTime = 0f;
        }*/
    }
    // Update is called once per frame
    
	// Update is called once per frame
	void Update ()
    {
        /*if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }	*/
	}
}
