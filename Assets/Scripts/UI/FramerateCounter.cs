using UnityEngine;
using TMPro;

public class FramerateCounter : MonoBehaviour
{
    public static FramerateCounter instance;
    public float PollingTime = 0.5f;
    
    public TextMeshProUGUI UIText;

    float currentDeltaTime = 0f;
    int currentFrameRate = 0;
    private void Awake() {
        instance = this;
    }

    void Update()
    {
        currentDeltaTime += Time.deltaTime;
        currentFrameRate++;
        if (currentDeltaTime >= PollingTime)
        {
            int framerate = Mathf.RoundToInt((float) currentFrameRate / currentDeltaTime);
            UIText.text = framerate.ToString();
            currentDeltaTime = 0f;
            currentFrameRate = 0;
        }
    }
}
