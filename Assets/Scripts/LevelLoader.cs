using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float loadScreenDelay = 3f;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTimeThenLoadNextScene());
        }
    }

    IEnumerator WaitForTimeThenLoadNextScene()
    {
        yield return new WaitForSeconds(loadScreenDelay);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void LoadYouLoseScene()
    {
        SceneManager.LoadScene("Lose Screen");
    }
}
