using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waitThenLoadGamePlay : MonoBehaviour
{
    AsyncOperation scene;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        scene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        scene.allowSceneActivation = false;
    }

    public void enableSceneAfterWait()
    {
        StartCoroutine(enableSceneLater(scene));
    }

    public IEnumerator enableSceneLater(AsyncOperation scene)
    {
        yield return new WaitForSeconds(1f);
        scene.allowSceneActivation = true;
    }

}
