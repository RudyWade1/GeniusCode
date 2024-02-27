using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _shootingTime;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootTatget;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_shootingTime);
        StartCoroutine(_shootingWorker());
    }

    private IEnumerator _shootingWorker()
    {
        Vector3 bulletDirection = (_shootTatget.position - transform.position).normalized;
        Bullet bullet = Instantiate(_bulletPrefab, transform.position + bulletDirection, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * _force;

        yield return _waitForSeconds;
        StartCoroutine(_shootingWorker());
    }
}
