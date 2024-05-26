using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDataClass 
{

    public static List<int> PlayerItemList = new();
    public static int PlayerHealth;
    public static int PlayerDamage;
    public static int PlayerArmor;
    public static int PlayerSpeed;
    public static int PlayerStage;
    public static int PlayerExp;
    public static int PlayerSkillPoints;
    public static int PlayerLevel;

    public static void SetPlayerData()
    {
        


        // SVE OVO MORA IDE IZ DATABAZE
        PlayerHealth = 200;
        PlayerDamage = 10;
        PlayerArmor = 0;
        PlayerSpeed=5; 
        PlayerStage=1;
        PlayerExp=200;
        Debug.Log("PlayerData initialized.");
    }
   
        
    
//PLAYER UNLOCKED ITEMS 
    public static void AddItem(int ItemID)
    {
        PlayerItemList.Add(ItemID);
    }

    public static void RemoveItem(int ItemID)
    {
        PlayerItemList.Remove(ItemID);
    }

    
    

   
    

}


