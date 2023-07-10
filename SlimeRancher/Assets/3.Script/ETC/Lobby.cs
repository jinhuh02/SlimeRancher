using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{

    public void StartGame_Btn()
    {
        FindObjectOfType<Loading>().isLoading = true;
        PlayerPrefs.SetString("SceneName", "SampleScene");
        SceneManager.LoadScene("LoadingScene");
    }

    public void ExitGame_Btn()
    {
        Application.Quit();
    }


}
