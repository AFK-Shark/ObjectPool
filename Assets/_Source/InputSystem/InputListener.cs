using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private PlayerShoot _playerShoot;
        public void Construct(PlayerShoot _playerShoot)
        {
            this._playerShoot = _playerShoot;
        }
        private void Update()
        {
            ListenShoot();
        }
        private void ListenShoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerShoot.Shoot();
            }

        }
    }
}