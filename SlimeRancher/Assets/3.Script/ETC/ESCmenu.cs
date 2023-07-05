using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ESCmenu : MonoBehaviour
{
    [SerializeField] GameObject ESC_menu;
    [SerializeField] GameObject option_menu;
    [SerializeField] GameObject op_gamePlay;
    [SerializeField] GameObject op_sound;
    [SerializeField] Button gamePlay_btn;

    public void ShowESC_UI()
    {
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.instance.isUIActivation = true;
        ESC_menu.SetActive(true);
        option_menu.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continue_Btn()
    {
        ESC_menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.isUIActivation = false;
        Debug.Log("계속하기");
        Time.timeScale = 1;
    }
    public void Option_Btn()
    {
        ESC_menu.SetActive(false);
        option_menu.SetActive(true);
        Debug.Log("옵션");
        op_gamePlay.SetActive(true);
        op_sound.SetActive(false);
        gamePlay_btn.Select();
    }

    public void GamePlayOption_Btn()
    {
        op_gamePlay.SetActive(true);
        op_sound.SetActive(false);
    }
    public void SoundOption_Btn()
    {
        op_gamePlay.SetActive(false);
        op_sound.SetActive(true);
    }

    public void OptionExit_Btn()
    {
        ESC_menu.SetActive(true);
        option_menu.SetActive(false);
        Debug.Log("옵션 나가기");
    }

    public void ExitGame_Btn()
    {
        Debug.Log("나가기");
        Time.timeScale = 1;
        SceneManager.LoadScene("LobbyScene");
    }
}
