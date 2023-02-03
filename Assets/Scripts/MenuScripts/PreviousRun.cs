using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreviousRun : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameBox;
    [SerializeField]
    TextMeshProUGUI time;
    [SerializeField]
    MovesCount movesCount;
    int prevMovesCount;

    [SerializeField]
    TextMeshProUGUI previousPercentageLit;

    private void Start() 
    {
        if (PlayerPrefs.HasKey("Name") == true)
        {
            nameBox.text = PlayerPrefs.GetString("Name");
        }
        if (PlayerPrefs.HasKey("Time") == true)
        {
            time.text = PlayerPrefs.GetString("Time");    
        }
        if (PlayerPrefs.HasKey("Moves") == true)
        {
            movesCount.AssignPrevMoves(PlayerPrefs.GetInt("Moves"));    
        }
    }

    public void SavePreviousRun()
    {
        PlayerPrefs.SetString("Time", time.text);
        Debug.Log("Saved Time in playerprefs " + PlayerPrefs.GetString("Time"));
        PlayerPrefs.SetInt("Moves", prevMovesCount);
        Debug.Log("Saved Moves in playerprefs " + PlayerPrefs.GetInt("Moves"));
    }

    public void AssignMovesCount(int count) 
    {
        prevMovesCount = count;
    }
    public void SavePercentage(string percentage)
    {
        PlayerPrefs.SetString("PercentageLit", percentage);
        Debug.Log("Saved PercentageLit " + percentage);
    }
    public void WritePreviousPercentageLit(string percentage) 
    {
        previousPercentageLit.text = percentage;
    }

    // Is run by the name inputfield
    public void SaveName(string name)
    {
        PlayerPrefs.SetString("Name", name);     
        Debug.Log("Saved Name " + name);   
    }

    public void WriteName()
    {
        nameBox.text = PlayerPrefs.GetString("Name");
    }
    public void SaveGridSizeToggle(bool toggle)
    {
        if (toggle == true)
        {
            PlayerPrefs.SetString("GridSizeToggle", "True");
        }
        else
        {
            PlayerPrefs.SetString("GridSizeToggle", "False");
        }
        Debug.Log("Saved GridSizeToggle " + PlayerPrefs.GetString("GridSizeToggle"));
    }
}
