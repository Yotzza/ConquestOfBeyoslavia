using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class CharacterDataClass : MonoBehaviour
{
    public static CharacterDataClass characterData;

    
    //charspeed = playerspeed*itemspeedmultipler
    private int CharacterHealth;
    //charspeed = playerspeed*itemspeedmultipler
    public int CharacterDamage;
    //charspeed = playerspeed*itemspeedmultipler
    public int CharacterArmor;
    //charspeed = playerspeed*itemspeedmultipler
    public int CharacterSpeed;

public static CharacterDataClass CharacterData
    {
        get
        {
            // If the instance doesn't exist yet, create it
            if (characterData == null)
            {
                // Look for an existing instance in the scene
                characterData = FindObjectOfType<CharacterDataClass>();

                // If no instance exists in the scene, create a new GameObject and attach the singleton script to it
                if (characterData == null)
                {
                    GameObject singletonObject = new GameObject("CharacterDataClass");
                    characterData = singletonObject.AddComponent<CharacterDataClass>();
                    DontDestroyOnLoad(singletonObject); // Make sure the singleton persists between scene changes
                }
            }
            return characterData;
        }
    }





    //init values-gleda se playerdata
    private void Awake()
    {
        // Example initialization
        CharacterHealth = 100;
        CharacterDamage = 10;
        CharacterArmor = 0;
        CharacterSpeed=5; 

        Debug.Log("CharacterData initialized.");
    }

    public void SetCharacterData()
    {
        CharacterHealth = 100;
        CharacterDamage = 10;
        CharacterArmor = 0;
        CharacterSpeed=5;

        Debug.Log("CharacterData set.");


    }


public int GetCharacterHealth()
    {
        return CharacterHealth;
    }


public void CharacterTakeDamage(int damage)
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

public void CharacterHeal(int health)
        {

            CharacterHealth += health;
            if (CharacterHealth > PlayerDataClass.PlayerData.PlayerHealth){
                CharacterHealth=PlayerDataClass.PlayerData.PlayerHealth;

            }

        }
    
public void Die()
    {

        
    }
}


