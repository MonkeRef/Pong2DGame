using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake () {
        playAgainButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Relooad the game scene
        });

        mainMenuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0); // Load the Main menu scene
        });
    }

    private void Start () {
        GameHandler.Instance.OnStateChanged += GameHandler_OnStateChanged;
        Hide();
    }
    private void GameHandler_OnStateChanged (object sender, System.EventArgs e) {
        if (GameHandler.Instance.IsGameOverWin()) {
            Show();
        }
    }

    private void Show () {
        gameObject.SetActive(true);
    }

    private void Hide () {
        gameObject.SetActive(false);
    }
}
