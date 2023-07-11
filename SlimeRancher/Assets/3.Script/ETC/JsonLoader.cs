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

    //�� ������ ��� �ٷ� ����

    //�ҷ����� �� ���
    //����� ���� ������ �ִ��� Ȯ��

    //������ ���ٴ� UI 
    //������ �ҷ����� â UI <-���������� �����ؾ���

    //���° ���̺� ��������
    //��¥, �ð�, ����, �κ��丮, ������ ��


    string path;
    public SaveFile savfiles = new SaveFile();
    public List<SaveData> saveData = new List<SaveData>();

    //���� ���� ������ 4��° ������ ��� - ���� �ʰ�! ���������
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


        //���̺����Ͽ� ����� ����� �ִٸ�, List saveData�� ������Ʈ�մϴ�
        if (File.Exists(path))
        {

            Debug.Log("����� ����� �����մϴ�");

            //�迭�� ��� ����Ʈ�� ��ȯ
            savfiles = JsonUtility.FromJson<SaveFile>(File_Read());

            for (int i = 0; i < savfiles.saveDatas.Length; i++)
            {
                saveData.Add(savfiles.saveDatas[i]); //saveData ����Ʈ�� 1~3���� �����Ͱ� ����
            }

        }
        else
        {
            Debug.Log("����� �������� �ʽ��ϴ�");
        }

    }


    //�����ϰ� ������
    public void SaveAndExitGame()
    {
        //���� �����Ȳ�� �����´�
        if (is4thFile || saveData.Count > selectFileNum)
        {
            saveData[selectFileNum] = FindObjectOfType<CurrentProgress>().UpdateSaveFileData();
            is4thFile = false;
        }
        else
        {
            //���� �����Ȳ�� �����ͼ� ���ο� ���Ϸ� ����
            saveData.Add(FindObjectOfType<CurrentProgress>().UpdateSaveFileData());
        }

        Debug.Log("�̷��� ������Ʈ �ϰڽ��ϴ� : " + saveData);

        File_Update();
    }


    //���� ������Ʈ
    private void File_Update()
    {
        //����Ʈ�� ����� ������ string����
        SaveFile saveFiles = new SaveFile
        {
            saveDatas = saveData.ToArray()
        };

        string jsonData = JsonUtility.ToJson(saveFiles);

        File.WriteAllText(path, jsonData);

        print("���� ������Ʈ : " + jsonData);
    }


    //���� �ҷ�����
    private string File_Read()
    {
        //���Ͽ� ����� ������ string����
        string jsonData = File.ReadAllText(path);

        print("���� �ҷ����� : " + jsonData);

        return jsonData;
    }


    public void RemoveSaveFile()
    {
        if(saveData.Count > selectFileNum)
        {
            saveData.RemoveAt(selectFileNum);
            Debug.Log("��ϻ����ϰ� ������ : " + saveData);
            //�ٽ� �ε�
            FindObjectOfType<Lobby>().UpdateUIText();
        }
    }

    //public bool isSaveLoad = false;
    public int selectFileNum = 0; //���õ� ��������
    //���� ���̺� �ε��϶�
    private void OnLevelWasLoaded(int level)
    {
        if (saveData.Count>selectFileNum && SceneManager.GetActiveScene().name == "SampleScene")
        {
            //����� ��� �ҷ�����

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

                Debug.Log("����� ����� �����մϴ�");

                //�迭�� ��� ����Ʈ�� ��ȯ
                savfiles = JsonUtility.FromJson<SaveFile>(File_Read());

                for (int i = 0; i < savfiles.saveDatas.Length; i++)
                {
                    saveData.Add(savfiles.saveDatas[i]); //saveData ����Ʈ�� 1~3���� �����Ͱ� ����
                }

            }
            else
            {
                Debug.Log("����� �������� �ʽ��ϴ�");
            }

        }
    }


}
