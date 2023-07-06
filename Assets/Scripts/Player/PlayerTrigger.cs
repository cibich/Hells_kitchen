using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Ingridients _ingridients;
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private List<Gun> _guns;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meat"))
        {
            Destroy(collision.gameObject);
            _ingridients.Meat = true;
        }
        if (collision.CompareTag("Pasta"))
        {
            Destroy(collision.gameObject);
            _ingridients.Pasta = true;
        }
        if (collision.CompareTag("Cheese"))
        {
            Destroy(collision.gameObject);
            _ingridients.Cheese = true;
        }
        if (collision.CompareTag("Broccoli"))
        {
            Destroy(collision.gameObject);
            _ingridients.Broccoli = true;
        }
        if (collision.CompareTag("Wine"))
        {
            Destroy(collision.gameObject);
            _ingridients.Wine = true;
        }
        if (collision.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            _playerController.AddHealth(2);
        }
        if (collision.CompareTag("Half_health"))
        {
            Destroy(collision.gameObject);
            _playerController.AddHealth(1);
        }
        if (collision.CompareTag("Bow"))
        {
            Destroy(collision.gameObject);
            _weaponManager.AddGun(_guns[0]);
        }
        if (collision.CompareTag("BananGun"))
        {
            Destroy(collision.gameObject);
            _weaponManager.AddGun(_guns[1]);
        }
        if (collision.CompareTag("Shotgun"))
        {
            Destroy(collision.gameObject);
            _weaponManager.AddGun(_guns[2]);
        }
        if (collision.CompareTag("SniperRifle"))
        {
            Destroy(collision.gameObject);
            _weaponManager.AddGun(_guns[3]);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Gas") && Input.GetKey(KeyCode.F))
        {
            _ingridients.Cooking();
        }
    }
}
