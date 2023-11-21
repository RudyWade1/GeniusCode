using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _spawnTime;

    private Transform _target;

    public void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        while (Input.GetMouseButtonDown(1))
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            var NewBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
