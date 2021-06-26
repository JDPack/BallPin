using System.Collections;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public TextMeshProUGUI loadingText;

    private float loadingTime = -2f;
    private string fmt = "00:00:0#";
    private bool isLoading = false;

    public void LoadPlayScene(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    //private void Update()
    //{
    //    Debug.Log("activeself " + loadingScreen.activeSelf);
    //    if (loadingScreen.activeSelf)
    //    {
    //        loadingTime += Time.deltaTime;
    //        int progress = (int)(loadingTime % 60);
    //        string progressLength = Mathf.Abs(progress).ToString(fmt);
    //        string progressToString = progress < 0 ? "-" + progressLength : progressLength;
    //        Debug.Log(progressToString);
    //        loadingText.SetText("Loading   " + progressToString);
    //    }
    //}

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = UnitySceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            loadingTime += Time.deltaTime;
            float progress = (float)(loadingTime % 60);
            Debug.Log("progress is" + progress);
            string progressLength = Mathf.Abs(progress).ToString(fmt);
            string progressToString = progress < -.5f ? "-" + progressLength : " " + progressLength;
            Debug.Log(progressToString);
            loadingText.SetText("Loading   " + progressToString);

            //once load has finished
            if (operation.progress >= 0.9f && progress > 0.0f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }

    }

}
