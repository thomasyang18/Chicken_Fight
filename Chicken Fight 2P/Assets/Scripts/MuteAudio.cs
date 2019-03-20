using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MuteAudio : MonoBehaviour
{
    public Text toggleText;
    private AudioSource a;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerSettings.instance.BGM;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Mute"))
        {
            if (a.enabled) a.enabled = false;
            else
            {
                a.enabled = true;
                a.Play();
            }
        }
        UpdateText();
    }


    void UpdateText() {
        if (a.enabled)
        {
            toggleText.text = "MUSIC: ON";
            toggleText.color = Color.green;
        }
        else {
            toggleText.text = "MUSIC: OFF";
            toggleText.color = Color.red;
        }
    }
}
