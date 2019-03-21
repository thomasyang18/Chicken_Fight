using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerSettings instance = null;
    public AudioSource BGM;
    [SerializeField] private AudioSource egg;
    [HideInInspector] public bool random;
    [HideInInspector] public bool camLock;
    Scene currentScene;
    string sceneName;
    [HideInInspector] public int selectedScene;
    string[] scenes = { "Grass", "House", "Factory", "City" };
    public float sfx, volume;
    void Awake()
    {
        random = false;
        sfx = 1;
        volume = 1;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        BGM.Play();
        camLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (Input.GetMouseButtonDown(0) && sceneName == "Menu") {
            eggShot();
        }
        if (Input.GetAxisRaw("Exit") == 1 && sceneName != "Menu") {
            SceneManager.LoadScene("Menu");
        }

    }

    
    public void setSFX(float i) {
       sfx = i;
        egg.volume = i;
    }

    public void setVolume(float i) {
        volume = i;
        BGM.volume = volume;
    }

    public void eggShot() {
        egg.Play();
    }

    public void flipRandom() {
        random = !random;
    }

    public void flipCameraLock() {
        camLock = !camLock;
    }

    public void levelGen() {
        if (random)
        {
            int load = Random.Range(0, scenes.Length);
            SceneManager.LoadScene(scenes[load]);
        }
        else {

            SceneManager.LoadScene(sceneName);
        }
    }

    public void initGame() {
        if (random)
        {
            levelGen();
        }
        else {
            SceneManager.LoadScene(scenes[selectedScene]);
        }
    }

    
}
