using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesCount : MonoBehaviour
{
    [SerializeField]
    PreviousRun previousRun;

    int count;

    TextMeshProUGUI moves;

    [SerializeField]
    TextMeshProUGUI prevMoves;
    private void Start()
    {
        moves = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        moves.text = "Moves: " + count;    
    }
    public void UpdateMoves()
    {
        count++;
    }
    public void ResetMoves()
    {
        AssignPrevMoves(count);
        previousRun.AssignMovesCount(count);
        count = 0;
    }
    public void AssignPrevMoves(int count)
    {
        prevMoves.text = "Moves: " + count;
    }
}
