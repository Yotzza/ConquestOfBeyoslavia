using UnityEngine;
using UnityEngine.UI;

public class ImageChangerClass : MonoBehaviour
{
    // This method must be public to show up in the dropdown
    public int EquipmentLevel;
    public Image targetImage;
public Image.Type imageType = Image.Type.Simple;
string imagePath;
void Awake()
    {
        
        LoadImage();
    }

void LoadImage()
    {
        
        int number;
        number=CharacterDataClass.CharacterItems[EquipmentLevel];
        if (number==0){
            return;
        }
        switch (EquipmentLevel)
            {
                case 0:
                    imagePath = "Weapon/" + number;
                    break;
                case 1:
                    imagePath = "BodyArmor/" + number;
                    break;
                case 2:
                    imagePath = "Equipment/" + number;
                    break;
                default:
                    Debug.LogError("Invalid equipment level specified: " + EquipmentLevel);
                    break;
            }
        // Construct the path to the image based on the number
        
        
        // Load the sprite from the Resources folder
        Sprite newSprite = Resources.Load<Sprite>(imagePath);
        
        if (newSprite != null)
        {
            // Set the loaded sprite to the target image
            targetImage.type = imageType;
            targetImage.preserveAspect = true;
            targetImage.sprite = newSprite;
            
        }
        else
        {
            Debug.LogError("Image not found at path: " + imagePath);
        }
    }
}