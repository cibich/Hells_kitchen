using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hp;
    private int _defaultCountHp = 6;

    private void OnEnable()
    {
        EventManager.PlayerHurt += UpdateHealthBar;
    }
    private void OnDisable()
    {
        EventManager.PlayerHurt -= UpdateHealthBar;
    }

    private void Start()
    {
        for (int i = 0; i < _defaultCountHp; i++)
        {
            _hp[i].SetActive(true);
        }
    }

    private void UpdateHealthBar(int currentHealth)
    {
        for (int i = 0; i < _hp.Count; i++)
        {
            if (i<currentHealth)
                _hp[i].SetActive(true);
            else
                _hp[i].SetActive(false);
        }
    }
}
