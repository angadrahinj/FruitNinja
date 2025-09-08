using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }
    private TextMeshProUGUI timerText;
    float elapsedTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}: {1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        elapsedTime = 0;
        timerText.text = "00:00";
    }
}
