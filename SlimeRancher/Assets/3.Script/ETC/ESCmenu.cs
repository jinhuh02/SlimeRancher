using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class ESCmenu : MonoBehaviour
{
    [Header("�ɼ� ȭ����ȯ")]
    [SerializeField] GameObject ESC_menu;
    [SerializeField] GameObject option_menu;
    [SerializeField] GameObject op_gamePlay;
    [SerializeField] GameObject op_sound;
    [SerializeField] Button gamePlay_btn;
    [SerializeField] Button sound_btn;
    [SerializeField] GameObject overwrite_menu;

    [Header("[�ػ� ����]")]
    [SerializeField] Dropdown resolution_dropdown;
    [SerializeField] Toggle fullScreen_toggle;
    public int selectResolution = 9; //�⺻��
    public bool fullScreen = false; //�⺻��
    int[] horizontal = new int[13];
    int[] vertical = new int[13];


    [Header("[Bloom On/Off]")]
    [SerializeField] Toggle bloom_Toggle;
    [SerializeField] GameObject bloom_object;

    [Header("[�þ� ũ��]")]
    [SerializeField] Slider viewSizeSlider;

    [Header("[���콺 ����]")]
    [SerializeField] Slider sensitivitySlider;

    [Header("[����� ����]")]
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

    [SerializeField] Text[] daysText = new Text[3];
    [SerializeField] Text[] timeText = new Text[3];
    [SerializeField] Text[] coinText = new Text[3];

    JsonLoader jsonLoader;

    private void Start()
    {
        #region �ػ� ���� ����

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

        //�⺻��
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

        jsonLoader = FindObjectOfType<JsonLoader>();
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
            case 0: //�⺻��
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
        Cursor.visible = true;
        GameManager.instance.isUIActivation = true;
        AudioManager.instance.Play_UI_Button(0);
        ESC_menu.SetActive(true);
        option_menu.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continue_Btn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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


    public void Is4thFileCheck()
    {
        if (jsonLoader.is4thFile)
        {
            //����� ������ �����ϴ� UI
            overwrite_menu.SetActive(true);

            //UI�� ������ ä���
            if (jsonLoader.saveData.Count > 0)
            {
                //����� ��� ����
                daysText[0].text = jsonLoader.saveData[0].days + "�� °";
                if (jsonLoader.saveData[0].hour > 9)
                {
                    if (jsonLoader.saveData[0].minute > 9)
                    {
                        timeText[0].text = jsonLoader.saveData[0].hour + ":" + jsonLoader.saveData[0].minute;
                    }
                    else
                    {
                        timeText[0].text = jsonLoader.saveData[0].hour + ":0" + jsonLoader.saveData[0].minute;
                    }
                }
                else
                {
                    if (jsonLoader.saveData[0].minute > 9)
                    {
                        timeText[0].text = "0" + jsonLoader.saveData[0].hour + ":" + jsonLoader.saveData[0].minute;
                    }
                    else
                    {
                        timeText[0].text = "0" + jsonLoader.saveData[0].hour + ":0" + jsonLoader.saveData[0].minute;
                    }
                }
                coinText[0].text = jsonLoader.saveData[0].coin.ToString();

            }
            else
            {
                //����� ��� ����
                daysText[0].text = "�� ��� ����";
                timeText[0].text = string.Empty;
                coinText[0].text = "0";
            }

            if (jsonLoader.saveData.Count > 1)
            {
                daysText[1].text = jsonLoader.saveData[1].days + "�� °";
                if (jsonLoader.saveData[1].hour > 9)
                {
                    if (jsonLoader.saveData[1].minute > 9)
                    {
                        timeText[1].text = jsonLoader.saveData[1].hour + ":" + jsonLoader.saveData[1].minute;
                    }
                    else
                    {
                        timeText[1].text = jsonLoader.saveData[1].hour + ":0" + jsonLoader.saveData[1].minute;
                    }
                }
                else
                {
                    if (jsonLoader.saveData[1].minute > 9)
                    {
                        timeText[1].text = "0" + jsonLoader.saveData[1].hour + ":" + jsonLoader.saveData[1].minute;
                    }
                    else
                    {
                        timeText[1].text = "0" + jsonLoader.saveData[1].hour + ":0" + jsonLoader.saveData[1].minute;
                    }
                }
                coinText[1].text = jsonLoader.saveData[1].coin.ToString();
            }
            else
            {
                daysText[1].text = "�� ��� ����";
                timeText[1].text = string.Empty;
                coinText[1].text = "0";
            }

            if (jsonLoader.saveData.Count > 2)
            {
                daysText[2].text = jsonLoader.saveData[2].days + "�� °";
                if (jsonLoader.saveData[2].hour > 9)
                {
                    if (jsonLoader.saveData[2].minute > 9)
                    {
                        timeText[2].text = jsonLoader.saveData[2].hour + ":" + jsonLoader.saveData[2].minute;
                    }
                    else
                    {
                        timeText[2].text = jsonLoader.saveData[2].hour + ":0" + jsonLoader.saveData[2].minute;
                    }
                }
                else
                {
                    if (jsonLoader.saveData[2].minute > 9)
                    {
                        timeText[2].text = "0" + jsonLoader.saveData[2].hour + ":" + jsonLoader.saveData[2].minute;
                    }
                    else
                    {
                        timeText[2].text = "0" + jsonLoader.saveData[2].hour + ":0" + jsonLoader.saveData[2].minute;
                    }
                }
                coinText[2].text = jsonLoader.saveData[2].coin.ToString();
            }
            else
            {
                daysText[2].text = "�� ��� ����";
                timeText[2].text = string.Empty;
                coinText[2].text = "0";
            }


        }
        else
        {
            ExitGame_Btn();
        }
    }

    public void SelectOverwriteFile(int num)
    {
        FindObjectOfType<JsonLoader>().selectFileNum = num;
    }

    public void ExitGame_Btn()
    {
        Time.timeScale = 1;
        FindObjectOfType<JsonLoader>().SaveAndExitGame();
        FindObjectOfType<Loading>().isLoading = true;
        PlayerPrefs.SetString("SceneName", "LobbyScene");
        SceneManager.LoadScene("LoadingScene");
    }


    #region �ػ�


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


    //��ư�� ������ ��
    public void ChangeResolution_Btn()
    {
        //���� ���� �ػ󵵸� �����տ� �����ϰ�
        PlayerPrefs.SetInt("selectResolution", selectResolution+1);

        //��üȭ�� ���ε� �����ϰ�
        PlayerPrefs.SetInt("fullScreen", fullScreen ? 1 : 2);

        //�ػ󵵸� �����Ѵ�
        ChangeResolution();
    }


    public void ChangeResolution()
    {
        Screen.SetResolution(horizontal[PlayerPrefs.GetInt("selectResolution")], vertical[PlayerPrefs.GetInt("selectResolution")], fullScreen);
    }

    #endregion


    #region �Ҹ�

    public void SetAudioMasterVolum(Slider slider)
    {
        if(slider.value == -40)
        {
            masterVolum = -80;
        }
        else
        {
            masterVolum = slider.value;
        }
        
        SetAudioVolum(0);
    }
    public void SetAudioBackgroundVolum(Slider slider)
    {
        if(slider.value == -40)
        {
            backgroundVolum = -80;
        }
        else
        {
            backgroundVolum = slider.value;
        }
        
        SetAudioVolum(1);
    }
    public void SetAudioEffextVolum(Slider slider)
    {
        if (slider.value == -40)
        {
            effectVolum = -80;
        }
        else
        {
            effectVolum = slider.value;
        }
        
        SetAudioVolum(2);
    }

    private void SetAudioVolum(int type)
    {
        switch (type)
        {
            case 0:
                mixer.SetFloat("master", masterVolum);
                if(masterVolum <= -40)
                {
                    PlayerPrefs.SetFloat("masterVolum", -80);
                    masterAudioText.text = "" + 0;
                }
                else
                {
                    PlayerPrefs.SetFloat("masterVolum", masterVolum);
                    masterAudioText.text = "" + (int)((masterVolum + 40) / 40 * 100);
                }
                
                break;
            case 1:
                mixer.SetFloat("background", backgroundVolum);
                if (backgroundVolum <= -40)
                {
                    Debug.Log(backgroundVolum);
                    PlayerPrefs.SetFloat("backgroundVolum", -80);
                    backgroundAudioText.text = "" + 0;
                }
                else
                {
                    Debug.Log(backgroundVolum);
                    PlayerPrefs.SetFloat("backgroundVolum", backgroundVolum);
                    backgroundAudioText.text = "" + (int)(((backgroundVolum + 40) / 40 * 100));
                }
                
                break;
            case 2:
                mixer.SetFloat("effect", effectVolum);
                if (effectVolum <= -40)
                {
                    PlayerPrefs.SetFloat("effectVolum", -80);
                    effextrAudioText.text = "" + 0;
                }
                else
                {
                    PlayerPrefs.SetFloat("effectVolum", effectVolum);
                    effextrAudioText.text = "" + (int)(((effectVolum + 40) / 40 * 100));
                }
                
                break;
        }
    }

    #endregion


    #region �� �� ����
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
