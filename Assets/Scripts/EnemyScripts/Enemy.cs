
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int speed;
    public int damage;
    public int expdrop;


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

    public void Hit()
    {
        currentHealth -= 20;
        Debug.Log(currentHealth);
        anim.SetTrigger("hit");
        
        if (currentHealth <= 0){
        PlayerDataClass.PlayerExp+=expdrop;
        Debug.Log(PlayerDataClass.PlayerExp);
        Destroy(gameObject);
        }
        
            
            
    }

}
