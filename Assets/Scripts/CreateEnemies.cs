using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform _player;

    private float _delay = 2;
    private Transform[] _points;
    private Coroutine _coroutine;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _coroutine = StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_enemy, _points[i].position, Quaternion.identity);
            _enemy.SetTarget(_player);

            yield return waitForSeconds;
        }
    }
}
