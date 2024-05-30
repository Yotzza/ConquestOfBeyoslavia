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
                    
            }
        // Construct the path to the image based on the number
        
        
        // Load the sprite from the Resources folder
        Sprite newSprite = Resources.Load<Sprite>(imagePath);

        ItemImage.sprite=newSprite;
        Health.text=Item.AllItemsList[ItemTier].ItemHealth.ToString();
        Damage.text=Item.AllItemsList[ItemTier].ItemDamage.ToString();
        Armor.text=Item.AllItemsList[ItemTier].ItemArmor.ToString();
        Speed.text=Item.AllItemsList[ItemTier].ItemSpeed.ToString();

        ItemName.text=Item.AllItemsList[ItemTier].ItemName.ToString();
        ItemDescription.text=Item.AllItemsList[ItemTier].ItemDescription.ToString();


        if(!PlayerDataClass.PlayerItemList.Contains(ItemTier)){
            PlayerDataClass.PlayerItemList.Add(ItemTier);
            Debug.Log("Inserted in playerlist - " + ItemTier);
        }
        else{
            Debug.Log("Playerlist already has - " + ItemTier);
        }

        //+0 +10 +20
        //int randomNumber = Random.Range(0, 2);
        //int RandomItemTier=3*CharacterDataClass.CharacterStage;

        
    }

    
    
    
}
