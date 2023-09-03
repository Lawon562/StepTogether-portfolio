using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAnim : MonoBehaviour
{
    Animator openAni;
    void Start()
    {
        openAni = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        openAni.SetTrigger("MapOpen");
    }
}
