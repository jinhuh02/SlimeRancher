using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class ESCmenu : MonoBehaviour
{
    [Header("옵션 화면전환")]
    [SerializeField] GameObject ESC_menu;
    [SerializeField] GameObject option_menu;
    [SerializeField] GameObject op_gamePlay;
    [SerializeField] GameObject op_sound;
    [SerializeField] Button gamePlay_btn;
    [SerializeField] Button sound_btn;

    [Header("[해상도 설정]")]
    [SerializeField] Dropdown resolution_dropdown;
    [SerializeField] Toggle fullScreen_toggle;
    public int selectResolution = 9; //기본값
    public bool fullScreen = false; //기본값
    int[] horizontal = new int[13];
    int[] vertical = new int[13];


    [Header("[Bloom On/Off]")]
    [SerializeField] Toggle bloom_Toggle;
    [SerializeField] GameObject bloom_object;

    [Header("[시야 크기]")]
    [SerializeField] Slider viewSizeSlider;

    [Header("[마우스 감도]")]
    [SerializeField] Slider sensitivitySlider;

    [Header("[오디오 설정]")]
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

        StartCoroutine(PlayerSetting_co());
    }

    IEnumerator PlayerSetting_co()
    {
        yield return null;

        if(PlayerPrefs.GetInt("selectResolution") != 0)
        {
            resolution_dropdown.value = PlayerPrefs.GetInt("selectResolution")-1;
        }
        else
        {
            resolution_dropdown.value = selectResolution;
        }
        
        switch (PlayerPrefs.GetInt("fullScreen"))
        {
            case 0: //기본값
                fullScreen = true;
                break;
            case 1:
                fullScreen = true;
                break;
            case 2:
                fullScreen = false;
                break;
        }
        
        switch (fullScreen)
        {
            case true:
                fullScreen_toggle.isOn = true;
                fullScreen_toggle.transform.GetChild(0).gameObject.SetActive(true);
                break;

            case false:
                fullScreen_toggle.isOn = false;
                fullScreen_toggle.transform.GetChild(0).gameObject.SetActive(false);
                break;
        }

        ChangeResolution();

        
        switch (PlayerPrefs.GetInt("bloom"))
        {
            case 1:
                GameManager.instance._bloom.active = false;
                bloom_Toggle.isOn = false;
                bloom_Toggle.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 2:
                GameManager.instance._bloom.active = true;
                bloom_Toggle.isOn = true;
                bloom_Toggle.transform.GetChild(0).gameObject.SetActive(true);
                break;
        }


        if(PlayerPrefs.GetFloat("viewSize") != 0)
        {
            viewSizeSlider.value = PlayerPrefs.GetFloat("viewSize");
            Camera.main.fieldOfView = viewSizeSlider.value;
            viewSizeSlider.transform.GetChild(3).GetComponent<Text>().text = "" + (int)viewSizeSlider.value;
        }
        
        if(PlayerPrefs.GetFloat("sensitivity") != 0)
        {
            FindObjectOfType<CameraController>().mouseSensitivity = PlayerPrefs.GetFloat("sensitivity");
            sensitivitySlider.transform.GetChild(3).GetComponent<Text>().text = "" + (int)sensitivitySlider.value;
        }

    }

    public void ShowESC_UI()
    {
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.instance.isUIActivation = true;
        AudioManager.instance.Play_UI_Button(0);
        ESC_menu.SetActive(true);
        option_menu.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continue_Btn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.isUIActivation = false;
        Time.timeScale = 1;
    }
    public void Option_Btn()
    {
        option_menu.SetActive(true);
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


    public void ExitGame_Btn()
    {
        Time.timeScale = 1;
        FindObjectOfType<Loading>().isLoading = true;
        PlayerPrefs.SetString("SceneName", "LobbyScene");
        SceneManager.LoadScene("LoadingScene");
    }


    #region 해상도


    public void SetResolution()
    {
        selectResolution = resolution_dropdown.value;
    }

    public void SetFullScreen()
    {
        this.fullScreen = fullScreen_toggle.isOn;
        if (this.fullScreen)
        {
            fullScreen_toggle.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            fullScreen_toggle.transform.GetChild(0).gameObject.SetActive(false);
        }
    }


    //버튼을 눌렀을 때
    public void ChangeResolution_Btn()
    {
        //값에 따라 해상도를 프리팹에 저장하고
        PlayerPrefs.SetInt("selectResolution", selectResolution+1);

        //전체화면 여부도 저장하고
        PlayerPrefs.SetInt("fullScreen", fullScreen ? 1 : 2);

        //해상도를 변경한다
        ChangeResolution();
    }


    public void ChangeResolution()
    {
        Screen.SetResolution(horizontal[PlayerPrefs.GetInt("selectResolution")], vertical[PlayerPrefs.GetInt("selectResolution")], fullScreen);
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
                mixer.SetFloat("master", masterVolum);
                PlayerPrefs.SetFloat("masterVolum", masterVolum);
                masterAudioText.text = "" + (int)((masterVolum+80) /80 * 100);
                break;
            case 1:
                mixer.SetFloat("background", backgroundVolum);
                PlayerPrefs.SetFloat("backgroundVolum", backgroundVolum);
                backgroundAudioText.text = "" + (int)(((backgroundVolum + 80) / 80 * 100));
                break;
            case 2:
                mixer.SetFloat("effect", effectVolum);
                PlayerPrefs.SetFloat("effectVolum", effectVolum);
                effextrAudioText.text = "" + (int)(((effectVolum + 80) / 80 * 100));
                break;
        }
    }

    #endregion


    #region 그 외 설정
    public void SetBloom()
    {
        if (bloom_Toggle.isOn)
        {
            GameManager.instance._bloom.active = true;
            bloom_Toggle.transform.GetChild(0).gameObject.SetActive(true);
            PlayerPrefs.SetInt("bloom", 2);
        }
        else
        {
            GameManager.instance._bloom.active = false;
            bloom_Toggle.transform.GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("bloom", 1);
        }
    }

    public void SetViewSize()
    {
        //60~90
        Camera.main.fieldOfView = viewSizeSlider.value;
        viewSizeSlider.transform.GetChild(3).GetComponent<Text>().text = "" + (int)viewSizeSlider.value;
        PlayerPrefs.SetFloat("viewSize", viewSizeSlider.value);

    }

    public void SetMouseSensitivity()
    {
        //1~600
        FindObjectOfType<CameraController>().mouseSensitivity = sensitivitySlider.value;
        sensitivitySlider.transform.GetChild(3).GetComponent<Text>().text = "" + (int)sensitivitySlider.value;
        PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);
    }


    #endregion
}
