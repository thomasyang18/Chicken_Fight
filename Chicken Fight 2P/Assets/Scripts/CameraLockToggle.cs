using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CameraLockToggle : MonoBehaviour
{
    TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        string basetext = "Camera Locked: ";
        if (!PlayerSettings.instance.camLock)
        {
            basetext += "No";
            t.color = Color.red;
        }
        else
        {
            basetext += "Yes";
            t.color = Color.green;
        }
        t.text = basetext;
    }
}
