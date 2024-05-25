using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
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

    
    

    public static List<int> CharacterItems = new List<int>(){ 0, 0, 0 };


   







    

    public static void SetCharacterData()
    {
        CharacterHealth = PlayerDataClass.PlayerHealth + GetCharacterEquipmentSkills(1);
        CharacterDamage = PlayerDataClass.PlayerDamage + GetCharacterEquipmentSkills(2);
        CharacterArmor = PlayerDataClass.PlayerArmor + GetCharacterEquipmentSkills(3);
        CharacterSpeed=PlayerDataClass.PlayerSpeed + GetCharacterEquipmentSkills(4);

        Debug.Log("CharacterData set.");


    }


public static void CharacterTakeDamage(int damage)
    {
        
        CharacterHealth -= damage;
        
        //healthText.text = Mathf.Clamp(currentHealth, 0, maxHealth).ToString();

        //if (damageImage != null)
        //{
        //    damageImage.gameObject.SetActive(true); // Activate the damage UI image
        //    Invoke("HideDamageImage", 0.2f); // Hide the damage UI image after a delay
        //}
//
        //if (currentHealth <= 0)
        //{
            //Die();
       // }


        
}

public static void CharacterHeal(int health)
        {

            CharacterHealth += health;
            if (CharacterHealth > PlayerDataClass.PlayerHealth){
                //CharacterHealth=PlayerDataClass.playerData.PlayerHealth;

            }

        }
    
public static void Die()
    {

        
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
    int SkillSum=0;
    
        for (int j = 0; j < 3; j++){
        //mozda mora checker dal ga ima
        int itemnumber=CharacterItems[j];
        if (itemnumber!=0){
            SkillSum += Item.ItemStatGetter(i,Item.AllItemsList[itemnumber]);

        }
        else{
            Debug.Log("no equipment in" + j + " slot");
        }
        
        
        
        }
            return SkillSum;
    }

}


