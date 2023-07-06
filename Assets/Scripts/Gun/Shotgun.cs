using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private int _qantityInSalvo = 5;
    [SerializeField] private float _bulletSpread;

    public override void Shot()
    {
        if (IsShotInRoom)
        {
            for (int i = 0; i < _qantityInSalvo; i++)
            {
                _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 lookDir = _mousePos - (Vector2)_shotPoint[0].transform.position;
                _shotPoint[0].transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg, Vector3.forward);
                GameObject bullet = Instantiate(_bullet, _shotPoint[0].position, _shotPoint[0].rotation);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = (lookDir + new Vector2(Random.Range(-_bulletSpread, _bulletSpread), Random.Range(-_bulletSpread, _bulletSpread))).normalized * _speedBullet;
            }
            _currentBullet--;
            EventManager.OnPlayerShot(_currentBullet);
        }
    }

    public override void Reload()
    {
        base.Reload();
    }
}
