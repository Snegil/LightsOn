using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [Header("Cursor Position")]
    [Space, SerializeField]
    Vector3 screenPosition;
    [SerializeField]
    Vector3 worldPosition;
    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    TimeCount timeCount;
    [SerializeField]
    MovesCount movesCount;
    [SerializeField]
    VictoryCount victoryCount;

    [SerializeField]
    GridSizeButton gridSizeButton;

    SpawnSwitches spawnSwitches;
    // Start is called before the first frame update
    void Start()
    {
        spawnSwitches = GetComponent<SpawnSwitches>();
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Mouse.current.position.ReadValue();
        screenPosition.z = Camera.main.nearClipPlane + 1;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    }
    public void OnClick(InputAction.CallbackContext context)
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(ray, 10, layerMask);

        if (context.phase == InputActionPhase.Started && rayHit.collider != null)
        {
            Vector2 hitPoint = new(Mathf.Round(rayHit.point.x), Mathf.Round(rayHit.point.y));
            hitPoint.y = Mathf.Abs(hitPoint.y);
            spawnSwitches.WhichSwitchClicked(hitPoint);
            movesCount.UpdateMoves();
            timeCount.StartCounting();
        }
    }
    public void GameReset()
    {
        victoryCount.GetSetVictoryReset = false;
        spawnSwitches.ToggleAllSwitchesToOff();
        spawnSwitches.SwitchesRandomOn();
        movesCount.ResetMoves();
        timeCount.ResetCount();
        spawnSwitches.DestroyAllSwitches();
        spawnSwitches.Spawn();

        if (gridSizeButton.getsetToggle == true)
        {
            PlayerPrefs.SetString("GridToggle", "True");
        }
        else
        {
            PlayerPrefs.SetString("GridToggle", "False");
        }
        Debug.Log(PlayerPrefs.GetString("GridToggle"));

    }
    public void CheatGame(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            spawnSwitches.GameCheat();
        }
    }
}
