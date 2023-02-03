using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchSound : MonoBehaviour
{
    [SerializeField]
    AudioClip switchClick;
 
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.pitch = 0 + transform.position.x / 2 + Mathf.Abs(transform.position.y / 2);
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(switchClick);
    }
}
