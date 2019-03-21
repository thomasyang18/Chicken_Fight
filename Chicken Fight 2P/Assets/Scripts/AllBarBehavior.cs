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
        backAffirm();
        bars = GetComponentsInChildren<BarOnOff>();
    }

    // Update is called once per frame
    void Update()
    {
        checkBars();

    }
    void backAffirm() {
        if (gameObject.CompareTag("Volume"))
        {
            power = PlayerSettings.instance.volume*10f;
        }
        else if (gameObject.CompareTag("SFX"))
        {
            power = PlayerSettings.instance.sfx * 10f;
        }
    }
    

    void fowardAffirm() { 
        if (gameObject.CompareTag("Volume"))
        {
            PlayerSettings.instance.setVolume(power / 10.0f);
        }
        else if (gameObject.CompareTag("SFX"))
        {
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
        fowardAffirm();
    }

    
    public void setPower(float i) {
        power = i;
    }

}
