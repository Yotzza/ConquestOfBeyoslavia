using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeal : MonoBehaviour
{
    public int HealAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CharacterDataClass.CharacterData.CharacterHeal(HealAmount);
        
       // Debug.Log(CharacterDataClass.CharacterData.GetCharacterHealth());

        Destroy(gameObject);
    }
}