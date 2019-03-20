using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBarBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private BarOnOff[] bars;
    private float power;
    void Start()
    {
        power = 10;
        bars = GetComponentsInChildren<BarOnOff>();
    }

    // Update is called once per frame
    void Update()
    {
        checkBars();
        if (gameObject.CompareTag("Volume"))
        {
            PlayerSettings.instance.setVolume(power / 10.0f);
        }
        else if (gameObject.CompareTag("SFX")) {
            PlayerSettings.instance.setSFX(power / 10.0f);
        }
    }

    private void checkBars() {
        // checks the bars before itself to make the game consistent with a filled up egg bar for volume/sound/etc.
        
            for (int i = 0; i < bars.Length; i++)
            {
                if (i < power) bars[i].setOn(true);
                else bars[i].setOn(false);
            }
        
    }

    
    public void setPower(float i) {
        power = i;
    }

}
