using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading3 : MonoBehaviour
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

        // Don't activate scene yet

        asyncOperation.allowSceneActivation = false;

        // Wait until the asynchronous scene is fully loaded

        while (!asyncOperation.isDone)
        {
            // Fill our loading slider

            loadingSlider.value = asyncOperation.progress / 0.9f;

            // Check if the scene has finished loading

            if (asyncOperation.progress >= 0.9f)
            {
                // Activate scene, when we press space

                if (Input.GetKeyDown(KeyCode.Space))
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
