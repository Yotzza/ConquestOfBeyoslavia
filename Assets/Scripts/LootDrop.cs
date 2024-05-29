using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootDrop : MonoBehaviour
{
   
    public Text ItemName;
    public Text ItemDescription;

    public Text Health;
    public Text Damage;
    public Text Armor;
    public Text Speed;

    public Image ItemImage;



    string imagePath;


    void Start()
    {
        int[] possibleValues = { 0, 10, 20 };
        // Get a random index from the array
        int randomIndex = Random.Range(0, possibleValues.Length);
        // Return the value at the random index
        Debug.Log(possibleValues[randomIndex]);


        int ItemTier=possibleValues[randomIndex]+CharacterDataClass.CharacterStage;
        
        
        Debug.Log(ItemTier);
        switch (ItemTier)
            {
                case <10:
                    imagePath = "Weapon/" + ItemTier;
                    break;
                case >=10 and <20:
                    imagePath = "BodyArmor/" + ItemTier;
                    break;
                case >=20:
                    imagePath = "Equipment/" + ItemTier;
                    break;
                default:
                    Debug.LogError("SOMETHING WENT WRONG 405");
                    break;
            }
        // Construct the path to the image based on the number
        
        
        // Load the sprite from the Resources folder
        Sprite newSprite = Resources.Load<Sprite>(imagePath);

        ItemImage.sprite=newSprite;

        Armor.text=Item.AllItemsList[2].ItemArmor.ToString();

        //+0 +10 +20
        //int randomNumber = Random.Range(0, 2);
        //int RandomItemTier=3*CharacterDataClass.CharacterStage;

        
    }

    
    
    
}
