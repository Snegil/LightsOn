using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    bool isOn = false;
    
    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField]
    Color colorOff;
    [SerializeField]
    Color colorOn;

    void Start()
    {
        isOn = false;
        if (Random.Range(0, 5) < 2)
        {
            isOn = true;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        RefreshColour();
    }
    public void ToggleSwitch()
    {
        isOn = !isOn;
        StartAnimation();
        RefreshColour();
    }
    //Lil cheat
    public void FlipSwitch(bool which)
    {
        if (which == true)
        {
            isOn = true;
            StartAnimation();
            RefreshColour();
        }
        if (which == false)
        {
            isOn = false;
            StartAnimation();
            RefreshColour();
        }
    }
    void RefreshColour()
    {
        if (isOn == true)
        {
            spriteRenderer.color = colorOn;
        }
        else
        {
            spriteRenderer.color = colorOff;
        }
    }
    public void StartAnimation()
    {
        animator.SetTrigger("Toggled");
    }
    public bool IsOn
    {
        get { return isOn; }
    }
}
