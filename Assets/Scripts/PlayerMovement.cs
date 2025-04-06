using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the player
    private Rigidbody2D rb2D;
    private Vector2 moveInput;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); // Get input from A/D or Left/Right keys
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }
}
