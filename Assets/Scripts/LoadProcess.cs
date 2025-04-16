using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static Loader Instance;
    [SerializeField] private float loadSeconds = 1f;
    private const float finalSeconds = 2f;
    private LevelConfig levelConfig;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartLoadPlayScene()
    {
        StartCoroutine(LoadPlayScene());
    }
    private IEnumerator LoadPlayScene()
    {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync("PlayScene");
        sceneLoad.allowSceneActivation = false;

        while (sceneLoad.progress < 0.9f)
        {
            yield return null; 
        }

        for (int i = 0; i < 10; i++)
        {
            EventBus.Publish(new OnLoadEvent());
            yield return new WaitForSeconds(loadSeconds-1f);
        }
        yield return new WaitForSeconds(finalSeconds);
        sceneLoad.allowSceneActivation = true;
    }
}
