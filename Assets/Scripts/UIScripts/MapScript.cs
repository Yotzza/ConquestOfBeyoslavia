using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Color greenColor;
    public Color yellowColor;
    public Color redColor;
    public Image targetImage;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDataClass.SetPlayerData();
        // Get the transform of the current GameObject
        Transform parentTransform = this.transform;
       
        for (int i = 0; i < 9 ; i++)
        {
            // Get the child at the current index
            

            // Get the Button component of the child
            Debug.Log(i);
            Transform child = parentTransform.GetChild(i);

            // Get the Button component of the child
            Button button = child.GetComponent<Button>();

            // If the Button component exists, change its image color
            
            
                Image buttonImage = button.GetComponent<Image>();
                if (PlayerDataClass.PlayerStage>i)
                {
                    
                    buttonImage.color = greenColor;
                    
                    button.interactable = true;
                }
                else if (PlayerDataClass.PlayerStage==i)
                {
                    Debug.Log(PlayerDataClass.PlayerStage + "uslo sa "+ i);
                    buttonImage.color = yellowColor;
                    //menja mapu
                    string imagePath = "Map/" + i;
                    Sprite newSprite = Resources.Load<Sprite>(imagePath);
                   
                    //targetImage.preserveAspect = true;
                    targetImage.sprite = newSprite;
                    button.interactable = true;
                }
                else
                {
                    buttonImage.color = redColor;
                    button.interactable = false;
                    
                }
            
        }
        
    }

    
}
