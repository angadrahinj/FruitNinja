using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public Image fadeImage;

    private Blade blade;
    private FruitSpawner spawner;

    #region Unity Functions
    private void Awake()
    {
        blade = FindFirstObjectByType<Blade>();
        spawner = FindAnyObjectByType<FruitSpawner>();
    }

    private void Start()
    {
        NewGame();
    }
    #endregion

    #region New Game
    private void NewGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        ScoreManager.Instance.CheckIfBestScore();
        ScoreManager.Instance.ResetScore();
        
        TimerManager.Instance.ResetTimer();

        ClearScene();
    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsByType<Fruit>(FindObjectsSortMode.None);

        foreach(Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsByType<Bomb>(FindObjectsSortMode.None);

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }
    #endregion

    #region Explode Functions

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        NewGame();

        elapsed = 0f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
    }
    #endregion
}
