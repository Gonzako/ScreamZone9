using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waitThenLoadGamePlay : MonoBehaviour
{

    public void loadNextScene()
    {
        var asyncScene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        asyncScene.allowSceneActivation = false;
        StartCoroutine(enableSceneLater(asyncScene));
    }

    public IEnumerator enableSceneLater(AsyncOperation scene)
    {
        yield return new WaitForSeconds(1f);
        scene.allowSceneActivation = true;
    }

}
