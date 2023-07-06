using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerShotHandler (int currentBullet);
    public static event PlayerShotHandler PlayerShot;

    public delegate void PlayerReloadGunHandler(int currentBullet);
    public static event PlayerReloadGunHandler PlayerReloadGun;

    public delegate void PlayerSwitchGunHandler(Sprite sprite);
    public static event PlayerSwitchGunHandler PlayerSwitchGun;

    public delegate void PlayerHurtHandler(int currentHealth);
    public static event PlayerHurtHandler PlayerHurt;

    public static event Action EnemyDied;

    public static void OnPlayerHurt(int currentHealth)
    {
        PlayerHurt?.Invoke(currentHealth);
    }

    public static void OnPlayerShot(int currentBullet)
    {
        PlayerShot?.Invoke(currentBullet);
    }

    public static void OnPlayerReload(int currentBullet)
    {
        PlayerReloadGun?.Invoke(currentBullet);
    }

    public static void OnPlayerSwitchGun(Sprite sprite)
    {
        PlayerSwitchGun?.Invoke(sprite);
    }

    public static void OnEnemyDied()
    {
        EnemyDied?.Invoke();
    }
}
