using UnityEngine.SceneManagement;
using Normal.Realtime;
using UnityEngine;

public class NormalSceneLoader : MonoBehaviour
{
    [SerializeField] private Realtime realTime;
    [SerializeField] private string roomName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;
    public void LoadScene()
    {
        if (isLoading) return;
        isLoading = true;

        realTime.Disconnect();
        realTime = null;

        SceneManager.LoadScene(sceneIndex);

        realTime = FindObjectOfType<Realtime>();
        realTime.Connect(roomName);

        isLoading = false;

    }
}
