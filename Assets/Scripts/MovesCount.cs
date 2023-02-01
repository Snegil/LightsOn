using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesCount : MonoBehaviour
{
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
        prevMoves.text = "Moves: " + count;
        count = 0;
    }
}
