using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance {  get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;

    private int winningDefiningScore = 3;

    private enum State {
        GamePlaying,
        GameOverWin,
        GameOverDefeat
    }

    private State state;
    private bool isGamePaused = false;

    private void Awake () {
        Instance = this;
        state = State.GamePlaying;
        Time.timeScale = 1f;
    }


    private void Update () {
        switch(state) {
            case State.GamePlaying: // GamePlaying
                // If player 1 score > player 2 score and player1 score is 3, State.GameOverWin, else State.GameOverDefeat
                if(GameplayUI.Instance.LeftPlayerScoreAmount() > GameplayUI.Instance.RightPlayerScoreAmount() && GameplayUI.Instance.LeftPlayerScoreAmount() == winningDefiningScore) {
                    state = State.GameOverWin;
                    Time.timeScale = 0f;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                } else if(GameplayUI.Instance.LeftPlayerScoreAmount() < GameplayUI.Instance.RightPlayerScoreAmount() && GameplayUI.Instance.RightPlayerScoreAmount() == winningDefiningScore){
                    state = State.GameOverDefeat;
                    Time.timeScale = 0f;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                } 
                break;
            case State.GameOverWin: // Use this state to activate the WinUI
                break;
            case State.GameOverDefeat: // Use this state to activate the DefeatUI
                break;
        }

        if (Input.GetKeyUp(KeyCode.Escape)) { // Pause game when Escape button pressed, If it doesn't work, change the KeyCode to something else
            TogglePauseGame();
        }
    }

    public bool IsGameOverWin () {
        return state == State.GameOverWin;
    }

    public bool IsGameOverDefeat () {
        return state == State.GameOverDefeat;
    }

    public void TogglePauseGame () {
        isGamePaused = !isGamePaused;
        if (isGamePaused) {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        } else {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }
}
