using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEx : MonoBehaviour
{
    //[HideInInspector]
    //public static bool fullScreenFlag = false;
    //public GameObject fullMapUI;
    Animator openAni;

    private void Start()
    {
        openAni = this.transform.GetComponentInParent<Animator>();
        openAni.SetBool("Open", false);
    }
    public void OnClick()
    {
        openAni.SetBool("Open", !openAni.GetBool("Open"));
        //fullScreenFlag = !fullScreenFlag;
        //fullMapUI.SetActive(fullScreenFlag);
    }
}
