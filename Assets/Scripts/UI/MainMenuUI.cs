using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Awake () {
        playButton.onClick.AddListener(() => {
            // Change to GameplayMenu
            SceneManager.LoadScene(1);
        });

        exitButton.onClick.AddListener(() => {  
            // Exit Application
            Application.Quit();
        });

        Time.timeScale = 1.0f; // Make sure time flows
    }

}
