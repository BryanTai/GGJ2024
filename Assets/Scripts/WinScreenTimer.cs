using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WinScreenTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winTimerText;
    private void Awake()
    {
        if(_winTimerText == null)
        {
            _winTimerText = GetComponent<TextMeshProUGUI>();
        }

        _winTimerText.text = UtilityMethods.FormatTimerFromTime(TimerCrossSceneInfo.FinalTime);
    }
}
