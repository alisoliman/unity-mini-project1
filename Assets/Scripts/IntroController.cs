using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

    public Button optionsButton;
    public Button gameButton;
    public Button muteButton;
    public Button howToButton;
    public Button creditsButton;
    public Button backButton;

    public Canvas mainCanvas;
    public Canvas subCanvas;



    void Start() {
        optionsButton.GetComponent<Button>().onClick.AddListener(optionsClicked);
        gameButton.GetComponent<Button>().onClick.AddListener(gameClicked);
        backButton.GetComponent<Button>().onClick.AddListener(backClicked);
        muteButton.GetComponent<Button>().onClick.AddListener(muteClicked);
        subCanvas.gameObject.SetActive(false);
    }

    void optionsClicked(){
        subCanvas.gameObject.SetActive(!subCanvas.gameObject.activeSelf);
    }

    void backClicked(){
        subCanvas.gameObject.SetActive(false);
    }

    void muteClicked(){
       AudioListener.pause = !AudioListener.pause;
    }

    void gameClicked(){
        SceneManager.LoadSceneAsync("Main");
    }

}
