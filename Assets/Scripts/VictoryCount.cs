using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryCount : MonoBehaviour
{
    int count;
    bool needReset = false;

    [SerializeField]
    TextMeshProUGUI victories;

    void Update()
    {
        victories.text = "Medals: " + count;
    }
    public void UpdateVictories()
    {
        if (needReset == false)
        {
            count++;
            needReset = true;
        }
    }
    public bool GetSetVictoryReset
    {
        get { return needReset; }
        set { needReset = value; }
    }
}
