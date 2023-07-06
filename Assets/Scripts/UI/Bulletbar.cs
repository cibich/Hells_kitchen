using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulletbar : MonoBehaviour
{
    [SerializeField] private Image _gunSprite;
    [SerializeField] private List<GameObject> _bullet;
    private int _defaultCount = 7;

    private void OnEnable()
    {
        EventManager.PlayerShot += UpdateMagazine;
        EventManager.PlayerReloadGun += UpdateMagazine;
        EventManager.PlayerSwitchGun += ChangeSprite;
    }
    private void OnDisable()
    {
        EventManager.PlayerShot -= UpdateMagazine;
        EventManager.PlayerReloadGun -= UpdateMagazine;
        EventManager.PlayerSwitchGun -= ChangeSprite;
    }

    private void Start()
    {
        for (int i = 0; i < _defaultCount; i++)
        {
            _bullet[i].SetActive(true);
        }
    }

    private void UpdateMagazine(int currentBullet)
    {
        for (int i = 0; i < _bullet.Count; i++)
        {
            if (i < currentBullet)
                _bullet[i].SetActive(true);
            else
                _bullet[i].SetActive(false);
        }
    }

    private void ChangeSprite(Sprite sprite)
    {
        _gunSprite.sprite = sprite;
    }

}
