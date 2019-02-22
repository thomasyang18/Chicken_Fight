using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update

    // Scenes are 42 tiles large by 24 tiles tall (then cap off top).
    // Camera size is 8.
    //

    public Text winText;
    public Text restartText;

    public int playerCount;
    private bool[] playerAlive;
    void Start()
    {
        playerAlive = new bool[playerCount];
        for (int i = 0; i < playerCount; i++)
        {
            playerAlive[i] = true;
        }
        

        updateText();
        
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
    }

    void updateText()
    {
        if (playerCount <= 1)
        {
            restartText.text = "Press Space to Continue...";
            if (playerCount == 1)
            {
                int player = findAlivePlayer();
                winText.text = "Player " + player + " WINS!";
            }
            else {
                winText.text = "Draw...";
            }
            // enable restart button
            if (Input.GetAxisRaw("Restart") == 1) {
                int load = Random.Range(1, 2);
                if (load == 1)
                {
                    SceneManager.LoadScene("Grass");
                }
                else if (load == 2){
                    SceneManager.LoadScene("House");
                }
            }
        }
        else
        {
            winText.text = "";
            restartText.text = "";
        }
    }

    private int findAlivePlayer() {
        for (int i = 0; i < playerAlive.Length; i++) {
            if (playerAlive[i]) return i+1;
        }
        return -1;
    }

    public void playerDied(int p) {
        playerAlive[p-1] = false;
        playerCount--;
    }
}
