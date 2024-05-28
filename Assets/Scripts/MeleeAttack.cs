using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator playerAnim;
    public float attackDelay;
    public Transform weaponTransform;
    public float weaponRange;
    public int weaponDamage;
    public LayerMask enemyLayer;
    public bool debounce = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("hello");
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        if (debounce == false)
        {
            debounce = true;
            playerAnim.Play("SwordSlash");
            yield return new WaitForSeconds(0.3f);
            Collider2D[] enemy = Physics2D.OverlapCircleAll(weaponTransform.position, weaponRange, enemyLayer);
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].GetComponent<Enemy>().Hit(weaponDamage);
            }
            yield return new WaitForSeconds(attackDelay);
            debounce = false;
        }
    }

}
