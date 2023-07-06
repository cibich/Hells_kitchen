using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected Sprite _sprite;
    [SerializeField] protected Transform[] _shotPoint;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected float _speedBullet;
    [SerializeField] protected int _maxBullet;
    [SerializeField] protected int _currentBullet;
    [SerializeField] protected Camera _cam;
    protected Vector2 _mousePos;
    protected bool IsShotInRoom = true;

    public virtual void Start()
    {
        _currentBullet = _maxBullet;
    }

    public virtual void Update()
    {
        PermissionToShoot();
    }

    public virtual void Shot()
    {
        if (IsShotInRoom)
        {
            for (int i = 0; i < _shotPoint.Length; i++)
            {
                _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 lookDir = (_mousePos - (Vector2)_shotPoint[i].transform.position); 
                GameObject bullet = Instantiate(_bullet, _shotPoint[i].position, Quaternion.AngleAxis(Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg, Vector3.forward));
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = lookDir.normalized * _speedBullet;
            }
            _currentBullet--;
            EventManager.OnPlayerShot(_currentBullet);
        }
    }

    public virtual void Reload()
    {
        if (_currentBullet != _maxBullet)
        {
            _currentBullet = _maxBullet;
            IsShotInRoom = true;
            EventManager.OnPlayerReload(_currentBullet);
        }
    }

    public virtual void SwitchGun()
    { 
        EventManager.OnPlayerSwitchGun(_sprite);
        EventManager.OnPlayerReload(_currentBullet);
    }

    protected void PermissionToShoot()
    {
        if (_currentBullet == 0)
            IsShotInRoom = false;
    }

}
