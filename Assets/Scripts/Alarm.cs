using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _turningSpeed;

    private float _minAlarmVolume = 0f;
    private float _maxAlarmVolume = 0.6f;

    private Coroutine _alarmChanging;

    public void TurnOn()
    {
        if (_alarmChanging != null)
        {
            StopCoroutine(_alarmChanging); 
        }

        _alarmChanging = StartCoroutine
            (ChangingVolume(_maxAlarmVolume));
    }

    public void TurnOff()
    {
        StopCoroutine(_alarmChanging);

        _alarmChanging = StartCoroutine
            (ChangingVolume(_minAlarmVolume));
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator ChangingVolume(float targetVolume)
    {
        if (_audioSource.volume == _minAlarmVolume)
            _audioSource.Play();

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards
                (_audioSource.volume, targetVolume,
                _turningSpeed * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == _minAlarmVolume)
            _audioSource.Stop();
    }
}