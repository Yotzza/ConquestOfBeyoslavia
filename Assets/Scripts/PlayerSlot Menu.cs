using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSlotMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

    

}
