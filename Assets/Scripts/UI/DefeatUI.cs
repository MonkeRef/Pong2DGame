using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatUI : MonoBehaviour {

    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake () {
        playAgainButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload Game Scene
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
        if (GameHandler.Instance.IsGameOverDefeat()) {
            Show();
        }
    }

    private void Update () {
        
    }

    private void Show () {
        gameObject.SetActive(true);
    }

    private void Hide () {
        gameObject.SetActive(false);

    }
}
