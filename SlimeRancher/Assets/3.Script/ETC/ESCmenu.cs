using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class ESCmenu : MonoBehaviour
{
    [SerializeField] GameObject ESC_menu;
    [SerializeField] GameObject option_menu;
    [SerializeField] GameObject op_gamePlay;
    [SerializeField] GameObject op_sound;
    [SerializeField] Button gamePlay_btn;
    [SerializeField] Button sound_btn;
    [SerializeField] Dropdown resolution_dropdown;
    [SerializeField] GameObject bloom_object;

    [Header("해상도 설정")]
    public int selectResolution = 9; //기본값
    public bool fullScreen = false; //기본값
    int[] horizontal = new int[13];
    int[] vertical = new int[13];


    [Header("오디오 설정")]
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterAudioSlider;
    [SerializeField] Slider backgroundAudioSlider;
    [SerializeField] Slider effextrAudioSlider;
    [SerializeField] Text masterAudioText;
    [SerializeField] Text backgroundAudioText;
    [SerializeField] Text effextrAudioText;
    float masterVolum = 0;
    float backgroundVolum = 0;
    float effectVolum = 0;


    private void Start()
    {
        #region 해상도 설정 저장

        horizontal[0] = 800;
        vertical[0] = 600;

        horizontal[1] = 1024;
        vertical[1] = 768;

        horizontal[2] = 1152;
        vertical[2] = 864;

        horizontal[3] = 1280;
        vertical[3] = 720;

        horizontal[4] = 1280;
        vertical[4] = 768;

        horizontal[5] = 1280;
        vertical[5] = 800;

        horizontal[6] = 1280;
        vertical[6] = 960;

        horizontal[7] = 1280;
        vertical[7] = 1024;

        horizontal[8] = 1366;
        vertical[8] = 768;

        //기본값
        horizontal[9] = 1600;
        vertical[9] = 900;

        horizontal[10] = 1600;
        vertical[10] = 1000;

        horizontal[11] = 1600;
        vertical[11] = 1200;

        horizontal[12] = 1920;
        vertical[12] = 1080;

        #endregion


        masterVolum = PlayerPrefs.GetFloat("masterVolum");
        backgroundVolum = PlayerPrefs.GetFloat("backgroundVolum");
        effectVolum = PlayerPrefs.GetFloat("effectVolum");

        masterAudioSlider.value = masterVolum;
        backgroundAudioSlider.value = backgroundVolum;
        effextrAudioSlider.value = effectVolum;

        SetAudioVolum(0);
        SetAudioVolum(1);
        SetAudioVolum(2);

        Debug.Log("masterVolum : " + masterVolum);
        Debug.Log("backgroundVolum : " + backgroundVolum);
        Debug.Log("effectVolum : " + effectVolum);
    }

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

        gamePlay_btn.GetComponent<Image>().color = new Color(0.9490196f, 0.8941177f, 0f);
        sound_btn.GetComponent<Image>().color = new Color(0f, 0.9490196f, 0.7098039f);

        //00F2B5 0/0.9490196/0.7098039
        //F2E400 0.9490196/0.8941177/0
    }

    public void GamePlayOption_Btn()
    {
        op_gamePlay.SetActive(true);
        op_sound.SetActive(false);

        gamePlay_btn.GetComponent<Image>().color = new Color(0.9490196f, 0.8941177f, 0f);
        sound_btn.GetComponent<Image>().color = new Color(0f, 0.9490196f, 0.7098039f);
    }
    public void SoundOption_Btn()
    {
        op_gamePlay.SetActive(false);
        op_sound.SetActive(true);

        gamePlay_btn.GetComponent<Image>().color = new Color(0f, 0.9490196f, 0.7098039f);
        sound_btn.GetComponent<Image>().color = new Color(0.9490196f, 0.8941177f, 0f);
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


    #region 해상도


    public void SetResolution()
    {
        selectResolution = resolution_dropdown.value;
        Debug.Log(selectResolution + " 변경");
    }

    public void SetFullScreen(Toggle fullScreen)
    {
        this.fullScreen = fullScreen.isOn;
        Debug.Log("fullScreen : " + this.fullScreen);
        if (this.fullScreen)
        {
            fullScreen.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            fullScreen.transform.GetChild(0).gameObject.SetActive(false);
        }
    }


    //버튼을 눌렀을 때
    public void ChangeResolution_Btn()
    {
        //값에 따라 해상도를 프리팹에 저장하고
        PlayerPrefs.SetInt("selectResolution", selectResolution);

        //전체화면 여부도 저장하고
        PlayerPrefs.SetInt("fullScreen", fullScreen ? 1 : 0);

        //해상도를 변경한다
        ChangeResolution();
    }


    public void ChangeResolution()
    {
        Screen.SetResolution(horizontal[PlayerPrefs.GetInt("selectResolution")], vertical[PlayerPrefs.GetInt("selectResolution")], fullScreen);
        //resolutionText.text = horizontal[PlayerPrefs.GetInt("selectResolution")] + " x " + vertical[PlayerPrefs.GetInt("selectResolution")];
        Debug.Log("적용되었습니다");
    }

    #endregion


    #region 소리

    public void SetAudioMasterVolum(Slider slider)
    {
        masterVolum = slider.value;
        SetAudioVolum(0);
    }
    public void SetAudioBackgroundVolum(Slider slider)
    {
        backgroundVolum = slider.value;
        SetAudioVolum(1);
    }
    public void SetAudioEffextVolum(Slider slider)
    {
        effectVolum = slider.value;
        SetAudioVolum(2);
    }

    private void SetAudioVolum(int type)
    {
        switch (type)
        {
            case 0:
                Debug.Log("master : " + masterVolum);
                mixer.SetFloat("master", masterVolum);
                PlayerPrefs.SetFloat("masterVolum", masterVolum);
                masterAudioText.text = "" + (int)((masterVolum+30) /30 * 100);
                break;
            case 1:
                Debug.Log("background : " + backgroundVolum);
                mixer.SetFloat("background", backgroundVolum);
                PlayerPrefs.SetFloat("backgroundVolum", backgroundVolum);
                backgroundAudioText.text = "" + (int)(((backgroundVolum + 30) / 30 * 100));
                break;
            case 2:
                Debug.Log("effect : " + effectVolum);
                mixer.SetFloat("effect", effectVolum);
                PlayerPrefs.SetFloat("effectVolum", effectVolum);
                effextrAudioText.text = "" + (int)(((effectVolum + 30) / 30 * 100));
                break;
        }
    }

    #endregion


    #region 그 외 설정
    public void SetBloom(Toggle setBloom)
    {
        Debug.Log("setBloom : " + setBloom.isOn);
        if (setBloom.isOn)
        {
            //bloom_object.SetActive(true);
            GameManager.instance._bloom.active = true;
            setBloom.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            //bloom_object.SetActive(false);
            GameManager.instance._bloom.active = false;
            setBloom.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void SetViewSize(Slider viewSize)
    {
        //60~90
        Camera.main.fieldOfView = viewSize.value;
        viewSize.transform.GetChild(3).GetComponent<Text>().text = "" + (int)viewSize.value;

    }

    public void SetMouseSensitivity(Slider sensitivity)
    {
        //1~600
        FindObjectOfType<CameraController>().mouseSensitivity = sensitivity.value;
        sensitivity.transform.GetChild(3).GetComponent<Text>().text = "" + (int)sensitivity.value;
    }


    #endregion
}
