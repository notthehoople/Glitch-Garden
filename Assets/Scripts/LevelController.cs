using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] GameObject winTextDisplay;
    [SerializeField] GameObject loseTextDisplay;
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winTextDisplay.SetActive(false);
        loseTextDisplay.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if ((numberOfAttackers <= 0) && (levelTimerFinished))
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winTextDisplay.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseTextDisplay.SetActive(true);
        // Stop the game speed as we want all action to stop
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
