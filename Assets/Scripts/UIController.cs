using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    [HideInInspector] public float CurrentTime;

    private bool _isTiming;

    private void Awake()
    {
        if(_timerText == null)
        {
            _timerText = GetComponentInChildren<TextMeshProUGUI>();
        }
        _isTiming = true;
        TimerCrossSceneInfo.FinalTime = 0f;
    }

    private void Update()
    {
        if(_isTiming)
        {
            CurrentTime += Time.deltaTime;
            _timerText.text = UtilityMethods.FormatTimerFromTime(CurrentTime);
        }
        
    }

    public void StopTheTimer()
    {
        _isTiming = false;
        TimerCrossSceneInfo.FinalTime = CurrentTime;
    }

}
