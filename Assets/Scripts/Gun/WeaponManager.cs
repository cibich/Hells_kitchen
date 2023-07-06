using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<Gun> _guns;
    private Gun _currentGun;
    private int _currentIndex = 0;
    private int _indexKey = 49;

    private void Start()
    {
        _currentGun = _guns[_currentIndex];
    }

    private void Update()
    {
        SwitchGun();

        if (Input.GetMouseButtonDown(0))
            _currentGun.Shot();

        if (Input.GetKeyDown(KeyCode.R))
            _currentGun.Reload();
    }

    private void SwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentGun = _guns[0];
            _currentGun.SwitchGun();
            Debug.Log("Switched to Pistol");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && (int)KeyCode.Alpha2-_indexKey < _guns.Count)
        {
            _currentGun = _guns[1];
            _currentGun.SwitchGun();
            Debug.Log("Switched to Shotgun");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && (int)KeyCode.Alpha3 - _indexKey < _guns.Count)
        {
            _currentGun = _guns[2];
            _currentGun.SwitchGun();
            Debug.Log("Switched to Sniper Rifle");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && (int)KeyCode.Alpha4 - _indexKey < _guns.Count)
        {
            _currentGun = _guns[3];
            _currentGun.SwitchGun();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && (int)KeyCode.Alpha5 - _indexKey < _guns.Count)
        {
            _currentGun = _guns[4];
            _currentGun.SwitchGun();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetKeyDown(KeyCode.Tab) || scroll>0)
            SelectNextWeapon();
        else if(scroll<0)
            SelectPreviusWeapon();

        void SelectNextWeapon()
        {
            _currentIndex++;
            if (_currentIndex >= _guns.Count)
                _currentIndex = 0;

            _currentGun = _guns[_currentIndex];
            _currentGun.SwitchGun();
        }

        void SelectPreviusWeapon()
        {
            _currentIndex--;
            if (_currentIndex < 0)
                _currentIndex = _guns.Count-1;

            _currentGun = _guns[_currentIndex];
            _currentGun.SwitchGun();
        }
    }

    public void AddGun(Gun gun)
    { 
        _guns.Add(gun);
    }
}
