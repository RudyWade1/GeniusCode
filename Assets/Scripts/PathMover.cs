using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _pathPoints;
    private int _currentPoint;

    private void Start()
    {
        _pathPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _pathPoints[i] = _path.GetChild(i);
    }

    private void Update()
    {
        Transform path = _pathPoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, path.position, _speed * Time.deltaTime);

        if (transform.position == path.position)
        {
            _currentPoint++;

            if (_currentPoint == _pathPoints.Length)
                _currentPoint = 0;
        }
    }
}
