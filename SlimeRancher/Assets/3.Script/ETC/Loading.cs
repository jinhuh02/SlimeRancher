using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public bool isLoading = false;
    private float time;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayerPrefs.SetString("SceneName", "LobbyScene");
        StartCoroutine(LoadAsynScene_co());
    }


    private void OnLevelWasLoaded(int level)
    {
        if (isLoading)
        {
            StartCoroutine(LoadAsynScene_co());
        }
    }

    IEnumerator LoadAsynScene_co()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("SceneName"));
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            time = +Time.time;

            if (time > 10)
            {
                operation.allowSceneActivation = true;
                isLoading = false;
            }

            yield return null;
        }

        yield break;
    }

}
