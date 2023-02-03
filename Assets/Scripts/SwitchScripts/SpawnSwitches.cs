using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SpawnSwitches : MonoBehaviour
{
    [SerializeField]
    GameObject[,] switches;

    [SerializeField]
    GameObject switchObject;

    [SerializeField]
    TimeCount timeCount;
    [SerializeField]
    VictoryCount victoryCount;

    [SerializeField]
    Transform percentageComplete;
    [SerializeField]
    TextMeshProUGUI percentageCompleteText;

    [SerializeField]
    GameObject resetNeededText;

    [SerializeField]
    GridSizeButton gridSize;


    [SerializeField]
    GameObject switchParent;

    AudioPlayer player;

    bool victoryCelebrationPlayed = false;

    float updateTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioPlayer>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer -= Time.deltaTime;
        if (updateTimer <= 0)
        {
            WritePercentageLit();
            updateTimer = 600;
        }
    }

    public void WhichSwitchClicked(Vector2 switchPos)
    {
        int x = (int)switchPos.x;
        int y = (int)switchPos.y;
        ToggleSwitch(x, y);
        NeighbouringSwitchesToggle(x, y);
        CheckIfVictorious();
    }
    void NeighbouringSwitchesToggle(int x, int y)
    {
        // X + 1
        if (x + 1 >= 0 && x + 1 < switches.GetLength(0)) 
        {
            ToggleSwitch(x + 1, y);
        }
        // X - 1
        if (x - 1 >= 0 && x - 1 < switches.GetLength(0))
        {
            ToggleSwitch(x - 1, y);
        }
        // Y + 1
        if (y + 1 >= 0 && y + 1 < switches.GetLength(1))
        {
            ToggleSwitch(x, y + 1);
        }
        // Y - 1
        if (y - 1 >= 0 && y - 1 < switches.GetLength(1))
        {
            ToggleSwitch(x, y - 1);
        }
    }
    void ToggleSwitch(int x, int y)
    {
        switches[x, y].GetComponent<Switch>().ToggleSwitch();
        WritePercentageLit();
    }
    void CheckIfVictorious()
    {
        int amountOn = CalculateAmountOn();

        if (amountOn == switches.GetLength(0) * switches.GetLength(1))
        {
            timeCount.StopCounting();
            victoryCount.UpdateVictories();
            if (victoryCelebrationPlayed == false)
            {
                player.PlayAudio();
                VictoryCelebration();    
                victoryCelebrationPlayed = true;
            }
            resetNeededText.SetActive(true);
        }
    }
    public void VictoryCelebration()
    {
        for (int i = 0; i < switches.GetLength(0); i++)
        {
            for (int j = 0; j < switches.GetLength(1); j++)
            {
                StartCoroutine(StartVictoryAnimation(i, j, (i + j) / 5f));
            }
        }
    }
    IEnumerator StartVictoryAnimation(int x, int y, float delay)
    {
        yield return new WaitForSeconds(delay);
        switches[x, y].GetComponent<Animator>().SetTrigger("Victory");
    }
    public void ToggleAllSwitchesToOff()
    {
        for (int x = 0; x < switches.GetLength(0); x++)
        {
            for (int y = 0; y < switches.GetLength(1); y++)
            {
                switches[x, y].GetComponent<Switch>().FlipSwitch(false);
            }
        }
    }
    public void GameCheat()
    {
        for (int x = 0; x < switches.GetLength(0); x++)
        {
            for (int y = 0; y < switches.GetLength(1); y++)
            {
                switches[x, y].GetComponent<Switch>().FlipSwitch(true);
            }
        }
    }
    public void Spawn()
    {
        switches = new GameObject[gridSize.getSize, gridSize.getSize];
        Camera.main.transform.position = new Vector3(switches.GetLength(0) / 2, switches.GetLength(1) / -2, -10);

        for (int y = 0; y < switches.GetLength(0); y++)
        {
            for (int x = 0; x < switches.GetLength(1); x++)
            {
                switches[x, y] = Instantiate(switchObject, new Vector3(x, -y), Quaternion.identity, switchParent.transform);
                switches[x, y].GetComponentInChildren<TMP_Text>().text = x + ", " + y;
            }
        }
        WritePercentageLit();
    }
    public void DestroyAllSwitches()
    {
        for (int y = 0; y < switches.GetLength(0); y++)
        {
            for (int x = 0; x < switches.GetLength(1); x++)
            {
                Destroy(switches[x, y]);
            }
        }
    }
    public void SwitchesRandomOn()
    {
        ToggleAllSwitchesToOff();
        for (int x = 0; x < switches.GetLength(0); x++)
        {
            for (int y = 0; y < switches.GetLength(1); y++)
            {
                if (Random.Range(0, 5) < 2)
                {
                    switches[x, y].GetComponent<Switch>().FlipSwitch(true);
                }
                else
                {
                    switches[x, y].GetComponent<Switch>().FlipSwitch(false);
                }
            }
        }
    }
    public string PercentageLit()
    {
        float amountOn = CalculateAmountOn();
        
        return System.Math.Round(amountOn / (gridSize.getSize * gridSize.getSize) * 100, 2) + "%";
    }
    public void WritePercentageLit()
    {
        percentageCompleteText.text = PercentageLit();
    }

    public int CalculateAmountOn()
    {
        int amountOn = 0;
        for (int x = 0; x < switches.GetLength(0); x++)
        {
            for (int y = 0; y < switches.GetLength(1); y++)
            {
                if (switches[x, y].GetComponent<Switch>().IsOn == true)
                {
                    amountOn++;
                }
            }
        }
        return amountOn;
    }
    public void ResetVictoryCelebrationPlayed()
    {
        victoryCelebrationPlayed = false;
    }
}
