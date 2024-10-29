using InputSystem;
using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private PlayerShoot playerShoot;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private int startValBullets;
        [SerializeField] private int maxPoolSize;

        private BulletPool _bulletPool;

        void Start()
        {
            inputListener.Construct(playerShoot);
            _bulletPool = new BulletPool(bulletPrefab, startValBullets, maxPoolSize);
            playerShoot.Construct(_bulletPool);
        }

        public void End()
        {
            _bulletPool.Unsubscribe();
        }
    }
}
