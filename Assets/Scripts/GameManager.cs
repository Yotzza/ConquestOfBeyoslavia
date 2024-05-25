using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Item.InitializeItems();
        // Ensure the CharacterDataClass instance is created at the start of the game
        PlayerDataClass.SetPlayerData();

        CharacterDataClass.SetCharacterData();
        
        //Debug.Log("started1");
        
    }
}