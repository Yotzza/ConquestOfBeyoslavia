using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterDataClass
{



    //charspeed = playerspeed*itemspeedmultipler
    public static int CharacterHealth;
    //charspeed = playerspeed*itemspeedmultipler
    public static int CharacterDamage;
    //charspeed = playerspeed*itemspeedmultipler
    public static int CharacterArmor;
    //charspeed = playerspeed*itemspeedmultipler
    public static int CharacterSpeed;

    public static int CharacterLevel;

    public static int CharacterStage;



    public static List<int> CharacterItems = new List<int>() { 0, 0, 0 };












    public static void SetCharacterData()
    {
        
        CharacterHealth = PlayerDataClass.PlayerHealth + GetCharacterEquipmentSkills(1);
        CharacterDamage = PlayerDataClass.PlayerDamage + GetCharacterEquipmentSkills(2);
        CharacterArmor = PlayerDataClass.PlayerArmor + GetCharacterEquipmentSkills(3);
        CharacterSpeed = PlayerDataClass.PlayerSpeed + GetCharacterEquipmentSkills(4);

        Debug.Log("CharacterData set.");


    }


    public static void CharacterTakeDamage(int damage)
    {

        
       float damageReduction = 1.0f - (float)CharacterArmor / 100.0f;
        Debug.Log(damageReduction);
        //Debug.Log(Mathf.RoundToInt(damage * (float)damageReduction));
        CharacterHealth -= Mathf.RoundToInt(damage * (float)damageReduction);
    }

    public static void CharacterHeal(int health)
    {

        CharacterHealth += health;
        if (CharacterHealth > PlayerDataClass.PlayerHealth)
        {
            //CharacterHealth=PlayerDataClass.playerData.PlayerHealth;

        }

    }

    




    public static void AddItem(int ItemID)
    {
        CharacterItems.Add(ItemID);
    }

    public static void RemoveItem(int ItemID)
    {
        CharacterItems.Remove(ItemID);
    }

    public static int GetCharacterEquipmentSkills(int i)
    {
        int SkillSum = 0;

        for (int j = 0; j < 3; j++)
        {
            //mozda mora checker dal ga ima
            int itemnumber = CharacterItems[j];
            if (itemnumber != 0)
            {
                //Debug.Log("YES equipment in" + j + " slot");
                SkillSum += Item.ItemStatGetter(i, Item.AllItemsList[itemnumber]);

            }
            else
            {
               // Debug.Log("no equipment in" + j + " slot");
            }



        }
        return SkillSum;
    }

}


