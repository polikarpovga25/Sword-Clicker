using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class StartMenuManager : MonoBehaviour, IPointerClickHandler
{
    public Image fadeOverlayImage;
    public AudioSource backgroundMusicSource;
    public AudioSource buttonClickSource;
    public AudioSource transitionSoundSource;
    public AudioClip backgroundMusic;
    public AudioClip clickSound;
    public AudioClip transitionSound;
    public string targetSceneName = "MainScene";
    public float fadeDuration = 1.0f;

    private bool isTransitioning = false;

    private void Start()
    {
        if (backgroundMusicSource != null && backgroundMusic != null)
        {
            backgroundMusicSource.clip = backgroundMusic;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }

        if (fadeOverlayImage != null)
        {
            fadeOverlayImage.gameObject.SetActive(true);
            StartCoroutine(FadeRoutine(1f, 0f));
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isTransitioning) return;

        isTransitioning = true;

        if (buttonClickSource != null && clickSound != null)
        {
            buttonClickSource.PlayOneShot(clickSound);
        }

        if (transitionSoundSource != null && transitionSound != null)
        {
            transitionSoundSource.PlayOneShot(transitionSound);
        }

        if (fadeOverlayImage != null)
        {
            StartCoroutine(FadeAndLoadRoutine());
        }
        else
        {
            LoadMainScene();
        }
    }

    private IEnumerator FadeRoutine(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = fadeOverlayImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            fadeOverlayImage.color = color;
            yield return null;
        }

        color.a = endAlpha;
        fadeOverlayImage.color = color;

        if (endAlpha == 0f)
        {
            fadeOverlayImage.gameObject.SetActive(false);
        }
    }

    private IEnumerator FadeAndLoadRoutine()
    {
        fadeOverlayImage.gameObject.SetActive(true);
        yield return StartCoroutine(FadeRoutine(0f, 1f));
        LoadMainScene();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
