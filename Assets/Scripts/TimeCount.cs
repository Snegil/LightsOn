using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    float timeSeconds;
    float timeMinutes;
    float timeHours;

    bool count = false;
    bool hardStopCount = false;
    TextMeshProUGUI text;
    [SerializeField]
    TextMeshProUGUI prevTime;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == true && hardStopCount == false)
        {
            timeSeconds += Time.deltaTime;

            if (timeSeconds >= 60)
            {
                timeMinutes++;
                timeSeconds = 0;
            }
            if (timeMinutes >= 60)
            {
                timeHours++;
                timeMinutes = 0;
            }
            text.text = PrintTime();
        }
    }
    public void StartCounting()
    {
        count = true;
    }
    public void StopCounting()
    {
        count = false;
        hardStopCount = true;
    }
    public void ResetCount()
    {
        prevTime.text = PrintTime();
        timeSeconds = 0;
        timeMinutes = 0;
        timeHours = 0;
        count = false;
        hardStopCount = false;
        text.text = PrintTime();
    }
    string PrintTime()
    {
        string text = timeHours + "h " + timeMinutes + "m " + Mathf.Round(timeSeconds) + "s";
        return text;
    }
}
