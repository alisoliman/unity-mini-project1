using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {


    public GameObject Canvas;
    public GameObject Camera;

    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;
    public Button pauseButton;

    bool Paused = false;

    void Start(){
        Canvas.gameObject.SetActive (false);
        resumeButton.GetComponent<Button>().onClick.AddListener(Resume);
        restartButton.GetComponent<Button>().onClick.AddListener(RestartGame);
        quitButton.GetComponent<Button>().onClick.AddListener(QuitGame);
        pauseButton.GetComponent<Button>().onClick.AddListener(pauseClicked);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseClicked();
        }
    }
    public void Resume(){
        Time.timeScale = 1.0f;
        Canvas.gameObject.SetActive (false);
//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Locked;
        Paused = false;
//        Camera.GetComponent<AudioSource>().Play ();
    }

    void RestartGame(){
        Resume();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadScene(currentScene);
        SceneManager.LoadScene(currentScene.name);
    }

    void QuitGame(){
        Resume();
//        Cursor.visible = true;
//        Cursor.lockState = CursorLockMode.None;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadScene(currentScene);
        SceneManager.LoadScene("Intro");
    }

    public void pauseClicked(){
        if (Paused == true) {
            Time.timeScale = 1.0f;
            Canvas.gameObject.SetActive(false);
//            Cursor.visible = false;
//            Cursor.lockState = CursorLockMode.Locked;
            //                Camera.GetComponent<AudioSource>().Play ();
            Paused = false;
        } else {
            Time.timeScale = 0.0f;
            Canvas.gameObject.SetActive(true);
//            Cursor.visible = true;
//            Cursor.lockState = CursorLockMode.None;
            //                Camera.GetComponent<AudioSource>().Pause ();
            Paused = true;
        }
    }
}    