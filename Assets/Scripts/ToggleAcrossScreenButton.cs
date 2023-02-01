using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAcrossScreenButton : MonoBehaviour
{
    [SerializeField]
    GameObject acrossScreenButton;
    void Start()
    {
        acrossScreenButton.SetActive(false);
    }
    public void ToggleASB()
    {
        acrossScreenButton.SetActive(!acrossScreenButton.activeSelf);
    }
}
