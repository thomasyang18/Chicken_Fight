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
        a = GetComponent<AudioSource>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Mute")) {
            a.enabled = !a.enabled;
        }
        UpdateText();
    }


    void UpdateText() {
        if (a.enabled)
        {
            toggleText.text = "MUSIC: ON";
        }
        else {
            toggleText.text = "MUSIC: OFF";
        }
    }
}
