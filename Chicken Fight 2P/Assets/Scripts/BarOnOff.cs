using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarOnOff : MonoBehaviour
{
    private bool isOn;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    private Image r; 
    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
        r = GetComponent<Image>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn) r.sprite = on;
        else r.sprite = off;
    }

    public void setOn(bool i) {
        isOn = i;
    }

    public bool getOn() {
        return isOn;
    }

    public void Clicked() {
        // set volume of parent to this. This is gonna be a bit hard i think.
        BarOnOff[] bars = transform.parent.gameObject.GetComponentsInChildren<BarOnOff>();
        for (int i = 0; i < bars.Length; i++) {
            if (bars[i] == this) {
                if (i == 0 && bars[0].isOn && !bars[1].isOn) {
                    bars[0].setOn(false);
                    transform.parent.gameObject.GetComponent<AllBarBehavior>().setPower(0);
                    return;
                }
                transform.parent.gameObject.GetComponent<AllBarBehavior>().setPower(i + 1);
                return;
            }
        }
    }

    

}
