using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconSelected : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public GameObject border;
    
    void Start()
    {
        border = GetComponentInChildren<RawImage>().gameObject;
        border.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    

    public void selected()
    {
        LevelSelect up = GetComponentInParent<LevelSelect>();
        up.clear();
        border.SetActive(true);
        up.sendLevel();
    }
}
