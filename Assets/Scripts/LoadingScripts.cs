using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;

public class LoadingScripts : MonoBehaviour
{
    private AsyncOperation asy;
    public Slider progressB;
    // Start is called before the first frame update
    void Start()
    {
        if (progressB)
        {
            progressB.value = 0;
        }
        StartCoroutine("LoadScence_4");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SetLoadingPercentage(float value)
    {
        progressB.value = value / 100;
    }
    IEnumerator LoadScence()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(1);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            SetLoadingPercentage(op.progress * 100);
            yield return new WaitForEndOfFrame();
        }
        SetLoadingPercentage(100);
        yield return new WaitForEndOfFrame();
        op.allowSceneActivation = true;
    }
    IEnumerator LoadScence_4()
    {
        int displayProgress = 0;

        int toProgress = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(1);
        op.allowSceneActivation = false;
        while (op.progress<0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }
        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }
    IEnumerator Load_1()
    {
        ResourceRequest r = Resources.LoadAsync("bg", typeof(AudioClip));
        while (!r.isDone)
        {
            yield return null;
        }
        var v = r.asset as AudioClip;
        AudioSource source = GetComponent<AudioSource>();
        source.clip = v;
        source.Play();
    }
}
