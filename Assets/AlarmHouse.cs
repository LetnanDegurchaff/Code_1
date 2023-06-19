using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AlarmHouse : MonoBehaviour
{
    [SerializeField] private UnityEvent _isSpaceAttacked;
    [SerializeField] private UnityEvent _isSpaceClear;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _turningSpeed;
    private float _minAlarmVolume = 0f;
    private float _maxAlarmVolume = 0.6f;

    private Coroutine _alarmChanging;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_alarmChanging != null)
        {
            StopCoroutine(_alarmChanging);
        }

        _alarmChanging = StartCoroutine(TurnOnAlarm());
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(_alarmChanging);
        _alarmChanging = StartCoroutine(TurnOffAlarm());
    }

    private IEnumerator TurnOnAlarm()
    {
        _audioSource.Play();

        while (_audioSource.volume < _maxAlarmVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(
            _audioSource.volume, _maxAlarmVolume,
            _turningSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator TurnOffAlarm()
    {
        while (_audioSource.volume > _minAlarmVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(
            _audioSource.volume, _minAlarmVolume,
            _turningSpeed * Time.deltaTime);

            yield return null;
        }

        _isSpaceClear.Invoke();
    }
}
