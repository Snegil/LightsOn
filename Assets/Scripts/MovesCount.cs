using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesCount : MonoBehaviour
{
    int count;

    [SerializeField]
    TextMeshProUGUI moves;

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
        count = 0;
    }
}
