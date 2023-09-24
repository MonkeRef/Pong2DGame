using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public static Ball Instance { get; private set; }

    [SerializeField] private float ballSpeed;

    private Vector2 bounceDir;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    private void Awake () {
        Instance = this;
        startPosition = transform.position;
    }

    private void Start () {
        rb = GetComponent<Rigidbody2D>();
        bounceDir = Vector2.one.normalized;
    }

    private void FixedUpdate () {
        rb.velocity = bounceDir * ballSpeed * Time.deltaTime;
    }
    public void ResetPosition () {
        transform.position = startPosition;
    }

    private void OnCollisionEnter2D (Collision2D collision) {

        if (collision.gameObject.CompareTag("Wall")) {
            bounceDir.y = -bounceDir.y;
        }else if (collision.gameObject.CompareTag("Player")) {
            ballSpeed += Random.Range(0.5f, 1.5f);
            bounceDir.x = -bounceDir.x;
        }

    }

}
