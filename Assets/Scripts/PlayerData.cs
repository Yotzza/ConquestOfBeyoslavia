using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDataClass : MonoBehaviour
{
    public static PlayerDataClass playerData;

    
    public int PlayerHealth;
    public int PlayerDamage;
    public int PlayerArmor;
    public int PlayerSpeed;

public static PlayerDataClass PlayerData
    {
        get
        {
            // If the instance doesn't exist yet, create it
            if (playerData == null)
            {
                // Look for an existing instance in the scene
                playerData = FindObjectOfType<PlayerDataClass>();

                // If no instance exists in the scene, create a new GameObject and attach the singleton script to it
                if (playerData == null)
                {
                    GameObject singletonObject = new GameObject("PlayerDataClass");
                    playerData = singletonObject.AddComponent<PlayerDataClass>();
                    DontDestroyOnLoad(singletonObject); // Make sure the singleton persists between scene changes
                }
            }
            return playerData;
        }
        
    }
    private void Awake()
    {
        // SVE OVO MORA IDE IZ DATABAZE
        PlayerHealth = 200;
        PlayerDamage = 10;
        PlayerArmor = 0;
        PlayerSpeed=5; 

        Debug.Log("CharacterData initialized.");
    }

    


    

}


