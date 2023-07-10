using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{

    public void StartGame_Btn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame_Btn()
    {
        Application.Quit();
    }


}
