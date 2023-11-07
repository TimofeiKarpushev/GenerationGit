using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    internal void SetTarget(Transform target)
    {
        _target = target;
    }

    void Update()
    {
        if (_target != null)
        {
            Vector3 direction = (_target.position - transform.position);
            direction.Normalize();

            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }
}
