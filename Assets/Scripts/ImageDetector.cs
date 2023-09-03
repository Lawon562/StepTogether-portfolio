using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;

public class ImageDetector : MonoBehaviour
{
    public BoxCollider detector;
    public ARSession session;
    public ARSessionOrigin origin;

    public bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag) return;
        if (detector.enabled)
        {
            session.Reset();
            
            origin.transform.position = this.transform.position;
            origin.transform.rotation = this.transform.rotation;
            flag = true;      
        }                     
                              
    }                         
}                             
                              