using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour {

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake () {
        resumeButton.onClick.AddListener(() => {
            GameHandler.Instance.TogglePauseGame(); // Resume by hiding the UI, altho can be done by pressing the previous determined keybind
        });

        mainMenuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0); // Load the Main menu scene
        });
    }

    private void Start () {
        Hide();
        GameHandler.Instance.OnGamePaused += GameHandler_OnGamePaused;
        GameHandler.Instance.OnGameUnpaused += GameHandler_OnGameUnpaused;
    }

    private void GameHandler_OnGamePaused (object sender, System.EventArgs e) {
        Show();
    }

    private void GameHandler_OnGameUnpaused (object sender, System.EventArgs e) {
        Hide();
    }

    private void Show () {
        gameObject.SetActive(true);
    }

    private void Hide () {
        gameObject.SetActive(false);

    }
}
