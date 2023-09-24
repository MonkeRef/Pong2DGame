using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGoalPost : MonoBehaviour
{
    public static RightGoalPost Instance { get; private set; }

    private int leftPlayerScore;

    private void Awake () {
        Instance = this;
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            leftPlayerScore++;
            GameplayUI.Instance.PlayerScoreGoal();
        }
    }

    public int LeftPlayerTempScoreAmount () {
        return leftPlayerScore;
    }
}
