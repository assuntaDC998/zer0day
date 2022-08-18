using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject loadingScreen;
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public Slider progressBar;
    float totalScreenProgress;

    // The Awake function is called on all objects in the scene before any object's Start function is called. 
    private void Awake(){
        manager = this;
        SceneManager.LoadScene((int)ScenesIndex.INTRO, LoadSceneMode.Additive);
    }

    public void LoadGame(){
        loadingScreen.gameObject.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)ScenesIndex.INTRO));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)ScenesIndex.MAIN_MENU));

        //StartCoroutine(GetSceneLoadProgress());
    }


    public IEnumerator GetSceneLoadProgress()
    {
        for(int i=0; i<scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalScreenProgress = 0;
                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalScreenProgress += operation.progress;

                }
                totalScreenProgress = (totalScreenProgress / scenesLoading.Count) * 100f;
                progressBar.value = Mathf.RoundToInt(totalScreenProgress);
                yield return null;
            }

        }

        loadingScreen.gameObject.SetActive(false);
    }
}
