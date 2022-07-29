using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform weaponPoint;
    [SerializeField] Transform BulletPrefab;
    ObjectPool<Transform> _pool;

    void Awake()
    {
        _pool = new ObjectPool<Transform>(() =>
        {
            return Instantiate(BulletPrefab);
        }, bullet =>
        {
            bullet.gameObject.SetActive(true);
        }, bullet =>
        {
            bullet.gameObject.SetActive(false);
        }, bullet =>
        {
            Destroy(bullet.gameObject);
        }, false, 10, 20);

    }
    public void Fire()
    {
        Instantiate(BulletPrefab, weaponPoint.position, weaponPoint.transform.rotation);
    }
}


