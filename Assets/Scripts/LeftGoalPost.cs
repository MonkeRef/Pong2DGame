using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGoalPost : MonoBehaviour
{
    public static LeftGoalPost Instance { get; private set; }

    private int rightPlayerScore;

    private void Awake () {
        Instance = this;
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            rightPlayerScore++;
            GameplayUI.Instance.PlayerScoreGoal();
        }
    }

    public int RightPlayerTempScoreAmount () {
        return rightPlayerScore;
    }
}
