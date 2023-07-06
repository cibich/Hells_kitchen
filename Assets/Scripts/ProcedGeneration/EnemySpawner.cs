using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemy;
    [SerializeField] private List<Vector2> _spawnPoints;
    [SerializeField] private List<Vector2> _lootPoints;
    [SerializeField] private Vector2 _nullPos;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < _enemy.Count; i++)
        {
            int random = Random.Range(0, _spawnPoints.Count);
            if (random % 2 == 0 && _spawnPoints[random] != _nullPos)
            {
                Instantiate(_enemy[i], _spawnPoints[random], Quaternion.identity);
                _spawnPoints[random] = _nullPos;
                _enemy[i] = null;
            }
            else if (random % 2 != 0 || _spawnPoints[random] == _nullPos)
            {
                for (int y = 0; y < _spawnPoints.Count; y++)
                {
                    if (y % 2==0 && _spawnPoints[y] != _nullPos)
                    {
                        Instantiate(_enemy[i], _spawnPoints[y] , Quaternion.identity);
                        _spawnPoints[y] = _nullPos;
                        _enemy[i] = null;
                        break;
                    }
                }
            }
        }

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if (_spawnPoints[i]!=_nullPos)
            {
                _lootPoints.Add(_spawnPoints[i]);
            }
        }
    }

    public void PointsAdd(Vector2 point)
    {
        _spawnPoints.Add(point);
    }
}
