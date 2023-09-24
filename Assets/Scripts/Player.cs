using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set; }

    [SerializeField] private int slideSpeed;
    [SerializeField] private bool isLeftPlayer;
    [SerializeField] private Rigidbody2D rb;

    private float playerMovement;
    private Vector3 startPosition;

    private void Awake () {
        Instance = this;
    }

    private void Start () {
        startPosition = transform.position;
    }

    private void Update () {
        if (isLeftPlayer) {
            playerMovement = Input.GetAxisRaw("Vertical");
        } else {
            playerMovement = Input.GetAxisRaw("Vertical2");
        }

        rb.velocity = new Vector2(rb.velocity.x, playerMovement * slideSpeed);
    }

    public void ResetPosition () {
         transform.position = startPosition;
    }
}
