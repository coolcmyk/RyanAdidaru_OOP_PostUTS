using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animatorScene;
    void Awake()
    {
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        animatorScene.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        Player.Instance.transform.position = new(0, 0);
        animatorScene.SetTrigger("Start");
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
