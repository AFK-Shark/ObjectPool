using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class Bullet : MonoBehaviour
    {
        public Action<Bullet> OnDisableBullet;
        [SerializeField] private float speed = 0f;
        [SerializeField] private float LiveTimeValue = 4;
        private float LiveTimeValueDefault;
        private void OnEnable()
        {
            LiveTimeValueDefault = LiveTimeValue;
        }
        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            LiveTimeValue -= Time.deltaTime;
            if (LiveTimeValue <= 0)
            {
                LiveTimeEnd();
            }
        }
        void LiveTimeEnd()
        {
            LiveTimeValue = LiveTimeValueDefault;
            gameObject.SetActive(false);
        }
        private void OnDisable()
        {
            OnDisableBullet?.Invoke(this);
        }
    }
}