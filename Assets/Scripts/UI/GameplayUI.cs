using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    public static GameplayUI Instance {  get; private set; }

    [SerializeField] private TextMeshProUGUI leftScoreText;
    [SerializeField] private TextMeshProUGUI rightScoreText;

    private int leftPlayerScoreLiveUpdate;
    private int rightPlayerScoreLiveUpdate;

    private void Awake () {
        Instance = this;
    }

    private void Update () {
        rightPlayerScoreLiveUpdate = LeftGoalPost.Instance.RightPlayerTempScoreAmount(); // Saving the current score for GameHandler Script
        leftPlayerScoreLiveUpdate = RightGoalPost.Instance.LeftPlayerTempScoreAmount(); // Saving the current score for GameHandler Script
    }

    public void PlayerScoreGoal () {
        rightScoreText.text = LeftGoalPost.Instance.RightPlayerTempScoreAmount().ToString(); // Add displayed score by 1
        leftScoreText.text = RightGoalPost.Instance.LeftPlayerTempScoreAmount().ToString(); // Add displayed score by 1

        Player.Instance.ResetPosition(); // Reset Player position
        Ball.Instance.ResetPosition(); // Reset Ball position
    }

    public int LeftPlayerScoreAmount () {
        return leftPlayerScoreLiveUpdate;
    }

    public int RightPlayerScoreAmount () {
        return rightPlayerScoreLiveUpdate;
    }

}
