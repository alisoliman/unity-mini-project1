using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

    public Button optionsButton;
    public Button gameButton;
    public Button muteButton;
    public Button howToButton;
    public Button creditsButton;

    public Canvas mainCanvas;
    public Canvas subCanvas;



    void Start() {
        optionsButton.GetComponent<Button>().onClick.AddListener(optionsClicked);
        gameButton.GetComponent<Button>().onClick.AddListener(gameClicked);
    }

    void optionsClicked(){

    }

    void gameClicked(){
        SceneManager.UnloadScene(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Main");
    }

}
