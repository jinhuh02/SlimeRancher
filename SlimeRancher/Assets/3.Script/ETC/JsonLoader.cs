using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;


[Serializable]
public class SaveData
{
    public int days;
    public int hour;
    public int minute;
    public int coin;
    public int[] slimeCount01 = new int[2];
    public int[] slimeCount02 = new int[2];
    public int[] inventory_item = new int[6];
    public int[] inventory_count = new int[6];
    public bool isClearSlimeBarrier = false;
    public bool isClearExpansionBarrier = false;
}

public class SaveFile
{
    public SaveData[] saveDatas;
}


public class JsonLoader : MonoBehaviour
{ 

    #region instance
    public static JsonLoader instance = null;

    #endregion

    //새 게임일 경우 바로 시작

    //불러오기 일 경우
    //저장된 게임 파일이 있는지 확인

    //없으면 없다는 UI 
    //있으면 불러오기 창 UI <-새게임으로 시작해야함

    //몇번째 세이브 파일인지
    //날짜, 시간, 코인, 인벤토리, 슬라임 수


    string path;
    public SaveFile savfiles = new SaveFile();
    public List<SaveData> saveData = new List<SaveData>();

    //새로 만든 파일이 4번째 파일일 경우 - 파일 초과! 덮어씌워야함
    public bool is4thFile = false;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }



        path = Path.Combine(Application.persistentDataPath + "/SaveFile.json");
        Debug.Log(path);


        //세이브파일에 저장된 기록이 있다면, List saveData에 업데이트합니다
        if (File.Exists(path))
        {

            Debug.Log("저장된 기록이 존재합니다");

            //배열로 담고 리스트로 변환
            savfiles = JsonUtility.FromJson<SaveFile>(File_Read());

            for (int i = 0; i < savfiles.saveDatas.Length; i++)
            {
                saveData.Add(savfiles.saveDatas[i]); //saveData 리스트에 1~3개의 데이터가 쌓임
            }

        }
        else
        {
            Debug.Log("기록이 존재하지 않습니다");
        }

    }


    //저장하고 나가기
    public void SaveAndExitGame()
    {
        //현재 진행상황을 가져온다
        if (is4thFile || saveData.Count > selectFileNum)
        {
            saveData[selectFileNum] = FindObjectOfType<CurrentProgress>().UpdateSaveFileData();
            is4thFile = false;
        }
        else
        {
            //현재 진행상황을 가져와서 새로운 파일로 저장
            saveData.Add(FindObjectOfType<CurrentProgress>().UpdateSaveFileData());
        }

        Debug.Log("이렇게 업데이트 하겠습니다 : " + saveData);

        File_Update();
    }


    //파일 업데이트
    private void File_Update()
    {
        //리스트에 저장된 내용을 string으로
        SaveFile saveFiles = new SaveFile
        {
            saveDatas = saveData.ToArray()
        };

        string jsonData = JsonUtility.ToJson(saveFiles);

        File.WriteAllText(path, jsonData);

        print("파일 업데이트 : " + jsonData);
    }


    //파일 불러오기
    private string File_Read()
    {
        //파일에 저장된 내용을 string으로
        string jsonData = File.ReadAllText(path);

        print("파일 불러오기 : " + jsonData);

        return jsonData;
    }


    public void RemoveSaveFile()
    {
        if(saveData.Count > selectFileNum)
        {
            saveData.RemoveAt(selectFileNum);
            Debug.Log("기록삭제하고 남은거 : " + saveData);
            File_Update();

            savfiles = JsonUtility.FromJson<SaveFile>(File_Read());

            saveData.Clear();
            for (int i = 0; i < savfiles.saveDatas.Length; i++)
            {
                saveData.Add(savfiles.saveDatas[i]);
            }


            //다시 로드
            FindObjectOfType<Lobby>().UpdateUIText();
        }
    }

    //public bool isSaveLoad = false;
    public int selectFileNum = 0; //선택된 게임파일
    //만약 세이브 로드일때
    private void OnLevelWasLoaded(int level)
    {
        if (saveData.Count>selectFileNum && SceneManager.GetActiveScene().name == "SampleScene")
        {
            //저장된 기록 불러오기

            FindObjectOfType<CurrentProgress>().LoadSaveData(
                saveData[selectFileNum].days, saveData[selectFileNum].hour, saveData[selectFileNum].minute, saveData[selectFileNum].coin, 
                saveData[selectFileNum].slimeCount01, saveData[selectFileNum].slimeCount02, 
                saveData[selectFileNum].inventory_item, saveData[selectFileNum].inventory_count,
                saveData[selectFileNum].isClearSlimeBarrier, saveData[selectFileNum].isClearExpansionBarrier);

            //isSaveLoad = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        else if(SceneManager.GetActiveScene().name == "LoadingScene")
        {
            saveData.Clear();
            Cursor.lockState = CursorLockMode.Confined;

            if (File.Exists(path))
            {

                Debug.Log("저장된 기록이 존재합니다");

                //배열로 담고 리스트로 변환
                savfiles = JsonUtility.FromJson<SaveFile>(File_Read());

                for (int i = 0; i < savfiles.saveDatas.Length; i++)
                {
                    saveData.Add(savfiles.saveDatas[i]); //saveData 리스트에 1~3개의 데이터가 쌓임
                }

            }
            else
            {
                Debug.Log("기록이 존재하지 않습니다");
            }

        }
    }


}
