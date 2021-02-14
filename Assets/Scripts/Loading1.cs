using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading1 : MonoBehaviour
{
    // On Start, start loading main Scene

    void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        // Load the main scene asynchronously ( in the background of this scene )

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");

        // Wait until the asynchronous scene is fully loaded

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
