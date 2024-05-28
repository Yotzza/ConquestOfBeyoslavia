using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;

public class Player : MonoBehaviour
{
    public SpriteRenderer weapon;
    [SerializeField] float moveSpeed = 6;

    Animator anim;
    Rigidbody2D rb;



    bool dead = false;

    float moveHorizontal, moveVertical;
    Vector2 movement;

    int facingDirection = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        WeaponSpriteChanger();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
            Hit(enemy.damage);

    }

    void Hit(int damage)
    {
        anim.SetTrigger("Hit");
        CharacterDataClass.CharacterTakeDamage(damage);
        Debug.Log(CharacterDataClass.CharacterHealth);
    }

    void Die()
    {
        dead = true;
        // poziva kraj igre
    }


    public void WeaponSpriteChanger(){
        string imagePath = "Weapon/" + CharacterDataClass.CharacterItems[0];
        Sprite newSprite = Resources.Load<Sprite>(imagePath);
        weapon.sprite=newSprite;
    }
}
