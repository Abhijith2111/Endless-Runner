using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private bool isSlowed = false;
    private float slowTimeRemaining = 0f;
    private float normalTimeScale = 1f;
    private float slowedTimeScale = 0.5f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (isSlowed)
        {
            slowTimeRemaining -= Time.unscaledDeltaTime;
            if (slowTimeRemaining <= 0)
            {
                ResetTimeScale();
            }
        }
    }

    public void ActivateSlowTime(float duration)
    {
        Time.timeScale = slowedTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;  // Keep physics in sync

        slowTimeRemaining = duration;
        isSlowed = true;
    }

    private void ResetTimeScale()
    {
        Time.timeScale = normalTimeScale;
        Time.fixedDeltaTime = 0.02f;

        isSlowed = false;
    }
  
}
