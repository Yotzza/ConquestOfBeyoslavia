using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterDataClass.CharacterTakeDamage(damageAmount);
        Debug.Log(CharacterDataClass.CharacterHealth);
    }
}
