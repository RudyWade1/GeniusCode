using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _shootingTime;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootTatget;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    private IEnumerator _shootingWorker()
    {
        Vector3 bulletDirection = (_shootTatget.position - transform.position).normalized;
        GameObject bullet = Instantiate(_bulletPrefab, transform.position + bulletDirection, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * _force;

        yield return new WaitForSeconds(_shootingTime);
        StartCoroutine(_shootingWorker());
    }
}
