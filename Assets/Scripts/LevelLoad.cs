using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {
    int currentSceneIndex;


    // Start is called before the first frame update
    void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void loadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void quitGame() {
        Application.Quit();
    }

    public void loadGame() {
        SceneManager.LoadScene("Game");
    }

    public void loadStart() {
        SceneManager.LoadScene("Start");
    }

    public void loadEnd() {
        SceneManager.LoadScene("End");
    }
}
