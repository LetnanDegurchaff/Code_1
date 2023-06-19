using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private int _speedR;

    private Vector3 _left = new Vector3(-1, 0, 0);
    private Vector3 _right = new Vector3(1, 0, 0);
    private Vector3 _forward = new Vector3(0, 0, 1);
    private Vector3 _back = new Vector3(0, 0, -1);
    private Vector3 _leftR = new Vector3(0, -1, 0);
    private Vector3 _rightR = new Vector3(0, 1, 0 );

    private float _start = 1;
    private float _end = 1000;
    private float _current = 5;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        //Debug.Log(_current);

        //_current = Mathf.MoveTowards(_start, _end, _maxSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            _transform.Translate(_left * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _transform.Translate(_right * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _transform.Translate(_forward * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _transform.Translate(_back * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _transform.Rotate(_leftR * Time.deltaTime * _speedR);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _transform.Rotate(_rightR * Time.deltaTime * _speedR);
        }
    }
}
