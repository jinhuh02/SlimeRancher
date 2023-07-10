using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    JsonLoader jsonLoader;

    [SerializeField] Text[] daysText = new Text[3];
    [SerializeField] Text[] timeText = new Text[3];
    [SerializeField] Text[] coinText = new Text[3];

    [SerializeField] GameObject loadFile_UI;
    [SerializeField] GameObject loadFile_Empty_UI;

    public void Start()
    {
        jsonLoader = FindObjectOfType<JsonLoader>();
        UpdateUIText();
    }

    public void UpdateUIText()
    {
        if (jsonLoader.saveData.Count > 0)
        {
            //저장된 기록 있음
            daysText[0].text = jsonLoader.saveData[0].days + "일 째";
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
            //저장된 기록 없음
            daysText[0].text = "새 기록 쓰기";
            timeText[0].text = string.Empty;
            coinText[0].text = "0";
        }

        if (jsonLoader.saveData.Count > 1)
        {
            daysText[1].text = jsonLoader.saveData[1].days + "일 째";
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
            daysText[1].text = "새 기록 쓰기";
            timeText[1].text = string.Empty;
            coinText[1].text = "0";
        }

        if (jsonLoader.saveData.Count > 2)
        {
            daysText[2].text = jsonLoader.saveData[2].days + "일 째";
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
            daysText[2].text = "새 기록 쓰기";
            timeText[2].text = string.Empty;
            coinText[2].text = "0";
        }
    }


    public void SetSelectFile(int fileNum)
    {
        Debug.Log("선택된 파일 : " + fileNum);
        jsonLoader.selectFileNum = fileNum;
    }

    public void LoadFile_Btn()
    {
        if (jsonLoader.saveData.Count > 0)
        {
            loadFile_UI.SetActive(true);
        }
        else
        {
            loadFile_Empty_UI.SetActive(true);
        }
    }

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
