using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animatorScene;
    [SerializeField] private int currentLevel = 1;
    void Awake()
    {
        //do something lul
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        animatorScene.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        Player.Instance.transform.position = new(0, 0);
        animatorScene.SetTrigger("Start");
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
    }

    public void IncrementLevel()
    {
        currentLevel++;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
