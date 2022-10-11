using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float _timer;
    private bool frozen;

    private void OnEnable()
    {
        PlayerCharacter.OnDeath += OnPlayerDeath;
    }
    
    private void OnDisable()
    {
        PlayerCharacter.OnDeath -= OnPlayerDeath;
    }

    private void Start()
    {
        _timer = 0;
    }

    private void Update()
    {
        if(frozen) {return;}
        _timer += Time.deltaTime;
        DisplayTime();
    }

    private void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(_timer / 60); 
        float seconds = Mathf.FloorToInt(_timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnPlayerDeath()
    {
       frozen = true;
       StartCoroutine(ResetTimer());
    }

    private IEnumerator ResetTimer()
    {

        yield return new WaitForSeconds(2f);
        _timer = 0;
        frozen = false;
    }

    public void SetFrozen()
    {
        frozen = true;
    }
}
