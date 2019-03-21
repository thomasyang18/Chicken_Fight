using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    private IconSelected[] levels;
    void Awake()
    {
        levels = GetComponentsInChildren<IconSelected>();
    }

    // Update is called once per frame
    void Update()
    {
        recieveLevel();
    }

    public void clear() {
        foreach (IconSelected icon in levels) {
            icon.border.SetActive(false);
        }
    }

    public void recieveLevel() {
        int i = PlayerSettings.instance.selectedScene;
        levels[i].border.SetActive(true);
    }

    public void sendLevel() {
        int i = 0;
        foreach (IconSelected icon in levels) {
            if (icon.border.activeSelf) {
                Debug.Log(i);
                PlayerSettings.instance.selectedScene = i;
                return;
            }
            i++;
        }
    }
}
