using UnityEngine.SceneManagement;
using Normal.Realtime;
using UnityEngine;
using System.Collections;

public class AdditiveSceneLoader : MonoBehaviour
{

    [SerializeField] private Realtime[] realTime;
    [SerializeField] private string roomName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;
    public void LoadScene()
    {
        if (isLoading) return;
        isLoading = true;

        StartCoroutine(LoadSceneAdditive());

    }

    IEnumerator LoadSceneAdditive()
    {

        var loadAsync = SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Additive);

        while (!loadAsync.isDone) yield return null;

        realTime = FindObjectsOfType<Realtime>();

        foreach(var rt in realTime)
        {
            if(!rt.connected) rt.Connect(roomName);

        }

        isLoading = false;
    }
}
