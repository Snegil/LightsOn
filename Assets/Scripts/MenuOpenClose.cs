using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpenClose : MonoBehaviour
{
    Animator menuAnimator;
    void Start()
    {
        menuAnimator = GetComponent<Animator>();    
    }
    public void PlayMenuAnimation()
    {
        menuAnimator.SetTrigger("OpenOrClose");
    }
}
