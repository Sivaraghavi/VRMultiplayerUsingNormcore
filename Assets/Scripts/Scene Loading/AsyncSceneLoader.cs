using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField] private Realtime realTime;
    [SerializeField] private string roomName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;
    public void LoadScene()
    {
        if (isLoading) return;
        isLoading = true;

        StartCoroutine(LoadSceneAsync());

    }

    IEnumerator LoadSceneAsync()
    {
        realTime.Disconnect(); 
        realTime = null;

        var loadAsync = SceneManager.LoadSceneAsync(sceneIndex);

        while (!loadAsync.isDone) yield return null;

        realTime = FindObjectOfType<Realtime>();
        realTime.Connect(roomName);

        isLoading = false;
    }

}
