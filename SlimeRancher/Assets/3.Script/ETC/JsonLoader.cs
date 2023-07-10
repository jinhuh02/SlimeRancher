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
    public int slimeCount01;
    public int slimeCount02;
    public int[] inventory_item = new int[4];
    public int[] inventory_count = new int[4];
}

public class SaveFile
{
    public SaveData[] saveDatas;
}


public class JsonLoader : MonoBehaviour
{

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


    private void Awake()
    {
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

            print("List = " + saveData);
        }
        else
        {
            Debug.Log("����� �������� �ʽ��ϴ�");
        }

        DontDestroyOnLoad(gameObject);
    }


    //�����ϰ� ������
    public void SaveAndExitGame()
    {
        //���� �����Ȳ�� �����´�
        if(saveData.Count > 0)
        {
            saveData[selectFileNum] = FindObjectOfType<CurrentProgress>().UpdateSaveFileData();
        }
        else
        {
            //���� �����Ȳ�� �����ͼ� ����
            saveData.Add(FindObjectOfType<CurrentProgress>().UpdateSaveFileData());
        }

        Debug.Log("������ �����Ȳ : " + saveData);

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


    public bool isSaveLoad = false;
    public int selectFileNum = 0; //���õ� ��������
    //���� ���̺� �ε��϶�
    private void OnLevelWasLoaded(int level)
    {
        if (isSaveLoad && SceneManager.GetActiveScene().name == "SampleScene")
        {
            //����� ��� �ҷ�����

            FindObjectOfType<CurrentProgress>().LoadSaveData(
                saveData[selectFileNum].days, saveData[selectFileNum].hour, saveData[selectFileNum].minute, saveData[selectFileNum].coin, 
                saveData[selectFileNum].slimeCount01, saveData[selectFileNum].slimeCount02, 
                saveData[selectFileNum].inventory_item, saveData[selectFileNum].inventory_count);

            isSaveLoad = false;
        }
    }

}
