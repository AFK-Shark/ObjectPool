using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Transform firepoint;
        private BulletPool BulletPool;
        public void Construct(BulletPool bulletPool)
        {
            BulletPool = bulletPool;
        }
        public void Shoot()
        {
            Debug.Log("Shoot");
            if (BulletPool.TryGetItem(out Bullet bullet))
            {
                Debug.Log(bullet);
                bullet.transform.position = firepoint.position;
                bullet.transform.rotation = firepoint.localRotation;
                bullet.gameObject.SetActive(true);
            }
        }
    }
}