
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int speed = 2;

    private int currentHealth;

    Animator anim;
    Transform target;

    private void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;

            //okrece neprijatelja levo il desno u zavisnosti gde je igrac
            var playerToRight = target.position.x > transform.position.x;
            transform.localScale = new Vector2(playerToRight ? -1 : 1, 1);

        }
    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hit");

        if (currentHealth <= 0)
            Destroy(gameObject);
    }

}
