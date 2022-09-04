using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UITimer : MonoBehaviour
{

    public TextMeshProUGUI TimerText;
    public UnityEvent OnTimerStartEvent;
    public UnityEvent OnTimerTickEvent;
    public UnityEvent OnTimerEndEvent;
    [SerializeField] private float currentTime = 0;
    [SerializeField] private float TimeTick = 1f;
    private IEnumerator _currentTimer;

    public void StartTimer(float time)
    {
        if (_currentTimer != null) {
            StopCoroutine(_currentTimer);
        }
        //Debug.Log(time);
        currentTime = time;
        _currentTimer = TimerUpdate();
        StartCoroutine(_currentTimer);
    }

    public void StopTimer()
    {
        if (_currentTimer != null) {
            StopCoroutine(_currentTimer);
        }
    }
    private IEnumerator TimerUpdate()
    {
        OnTimerStartEvent.Invoke();
        while (currentTime > 0)
        {
            currentTime--;
            TimerText.text = currentTime.ToString();
            OnTimerTickEvent.Invoke();
            yield return new WaitForSecondsRealtime(TimeTick);
        }
        OnTimerEndEvent.Invoke();
    }

    private void OnValidate()
    {
        TimerText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
