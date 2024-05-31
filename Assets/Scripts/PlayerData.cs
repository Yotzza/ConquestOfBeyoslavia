using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class PlayerDataClass
{

    public static int PlayerID;
    public static List<int> PlayerItemList = new();
    public static int PlayerHealth;
    public static int PlayerDamage;
    public static int PlayerArmor;
    public static int PlayerSpeed;
    public static int PlayerStage;

    public static int PlayerExp;
    public static int PlayerSkillPoints;
    public static int PlayerLevel;

    public static string PlayerColorHex;
    public static int PlayerFaceID;

    public static void SetPlayerData()
    {

        
    


        // SVE OVO MORA IDE IZ DATABAZE
        PlayerItemList.Clear();
        PlayerItemList.Add(0);
        PlayerFaceID=0;
        PlayerColorHex="#FF5733";
        PlayerHealth = 200;
        PlayerDamage = 10;
        PlayerArmor = 0;
        PlayerSpeed = 5;
        PlayerStage = 0;
        PlayerExp = 200;

        PlayerSkillPoints=3;

        PlayerFaceID=1;
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
 
 //TREBA SE STAVI NEGDE OVO
    public static void ExpChecker()
    {
        if (PlayerExp>=1000){
            PlayerExp-=1000;
            PlayerLevel+=1;
            PlayerSkillPoints+=1;
            Debug.Log("Level up");
        }
    }

    public static Sprite FaceImageChanger(int faceid)
    {
        string imagePath = "PlayerModel/" + faceid;
        Sprite newSprite = Resources.Load<Sprite>(imagePath);
        return newSprite;
    }

}


