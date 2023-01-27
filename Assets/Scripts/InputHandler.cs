using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    MovesCount movesCount;
    [SerializeField]
    VictoryCount victoryCount;

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
            Vector2 hitPoint = new Vector2(Mathf.Round(rayHit.point.x), Mathf.Round(rayHit.point.y));
            hitPoint.y = Mathf.Abs(hitPoint.y);
            spawnSwitches.WhichSwitchClicked(hitPoint);
            movesCount.UpdateMoves();
        }
    }
    public void GameReset(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            movesCount.ResetMoves();
            victoryCount.GetSetVictoryReset = false;
            spawnSwitches.ToggleAllSwitchesToOff();
        }
    }
    public void CheatGame(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            spawnSwitches.GameCheat();
        }
    }
    public void QuitGame(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
