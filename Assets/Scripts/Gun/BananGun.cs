using UnityEngine;

public class BananGun : Gun
{
    [SerializeField] private float gravity;
    public override void Shot()
    {
        if (IsShotInRoom)
        {
            for (int i = 0; i < _shotPoint.Length; i++)
            {
                _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 lookDir = (_mousePos - (Vector2)_shotPoint[i].transform.position);
                GameObject bullet = Instantiate(_bullet, _shotPoint[i].position, Quaternion.AngleAxis(Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg, Vector3.forward));
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

                float distance = lookDir.magnitude;
                float time = distance / _speedBullet;

                // ¬ычисл€ем начальную скорость по горизонтали и вертикали
                float vx = lookDir.x / time;
                float vy = (lookDir.y / time) + (0.5f * Mathf.Abs(gravity) * time);

                // Ќазначаем начальную скорость
               Vector2 initialVelocity = new Vector2(vx, vy);

                // ѕримен€ем начальную скорость
                bulletRb.velocity = initialVelocity;
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
