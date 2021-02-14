using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading2 : MonoBehaviour
{
    [Header("Slider | Reference")] public Slider loadingSlider;

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
            // Fill our loading slider

            loadingSlider.value = asyncOperation.progress / 0.9f;

            yield return null;
        }
    }
}
