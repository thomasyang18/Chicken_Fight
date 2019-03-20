using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private float buttonOnHoverScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scaleUp() {
        transform.localScale += new Vector3(buttonOnHoverScale, buttonOnHoverScale, buttonOnHoverScale);
    }

    public void scaleDown() {
        transform.localScale -= new Vector3(buttonOnHoverScale, buttonOnHoverScale, buttonOnHoverScale);
    }

    public void exitGame() {
        // only for exit button
        Application.Quit();
        // for editor purposes
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void playGame() {
        PlayerSettings.instance.initGame();
    }
}
