using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] float moveSpeed = 6;

    Animator anim;
    Rigidbody2D rb;

    int maxHealth = 100;
    int currentHealth;

    bool dead = false;

    float moveHorizontal, moveVertical;
    Vector2 movement;

    int facingDirection = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (dead)
        {
            movement = Vector2.zero;
            anim.SetFloat("Velocity", 0);
            return;
        }

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;

        anim.SetFloat("velocity", movement.magnitude);

        if (movement.x != 0)
            facingDirection = movement.x > 0 ? 1 : -1;

        transform.localScale = new Vector2(facingDirection, 1);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
}
