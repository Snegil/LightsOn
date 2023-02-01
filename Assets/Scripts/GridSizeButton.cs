using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridSizeButton : MonoBehaviour
{
    // FALSE == 5x5; TRUE == 9x9
    [SerializeField]
    bool toggle = false;
    int size = 5;
    Image image;

    [SerializeField]
    Sprite leftLeaning;
    [SerializeField]
    TextMeshProUGUI leftText;
    [SerializeField]
    Sprite rightLeaning;
    [SerializeField]
    TextMeshProUGUI rightText;

    Color greenColour = new Color(0.2313726f, 0.3607843f, 0, 1);
    Color standardColour;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        standardColour = image.color;
        if (toggle == false)
        {
            image.sprite = leftLeaning;
            leftText.color = greenColour;
            rightText.color = standardColour;
            size = 5;
        }
        if (toggle == true)
        {
            image.sprite = rightLeaning;
            leftText.color = standardColour;
            rightText.color = greenColour;
            size = 9;
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    public void OnClick()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            image.sprite = leftLeaning;
            leftText.color = greenColour;
            rightText.color = standardColour;
            size = 5;
        }
        if (toggle == true)
        {
            image.sprite = rightLeaning;
            leftText.color = standardColour;
            rightText.color = greenColour;
            size = 9;
        }
    }
    public int getSize
    {
        get { return size; }
    }
}
