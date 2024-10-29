using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class BulletPool
    {
        private Bullet _bullet;
        private Queue<Bullet> _bullets = new Queue<Bullet>();
        private int _startPoolSize;
        private int _maxPoolSize;
        private int _currentPoolSize;

        public BulletPool(Bullet bullet, int startPoolSize, int maxPoolSize)
        {
            _bullet = bullet;
            _startPoolSize = startPoolSize;
            _maxPoolSize = maxPoolSize;
            _currentPoolSize = 0;
            InitPool();
        }

        private void InitPool()
        {
            for (int i = 0; i < _startPoolSize; i++)
            {
                CreateBullet();
            }
        }

        private Bullet CreateBullet()
        {
            Bullet bulletInst = Object.Instantiate(_bullet);
            bulletInst.OnDisableBullet += ReturnToPool;
            _bullets.Enqueue(bulletInst);
            _currentPoolSize++;
            return bulletInst;
        }

        public bool TryGetItem(out Bullet bullet)
        {
            if (_bullets.Count > 0)
            {
                bullet = _bullets.Dequeue();
                return true;
            }

            if (_currentPoolSize < _maxPoolSize)
            {
                bullet = CreateBullet();
                return true;
            }

            bullet = null;
            return false;
        }

        public void ReturnToPool(Bullet bullet)
        {
            _bullets.Enqueue(bullet);
            Debug.Log($"Bullets in pool: {_bullets.Count}");
        }

        public void Unsubscribe()
        {
            foreach (Bullet bullet in _bullets)
            {
                bullet.OnDisableBullet -= ReturnToPool;
            }
        }
    }
}
