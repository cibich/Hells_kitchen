using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _leftSector;
    [SerializeField] private GameObject[] _rightSector;
    [SerializeField] private GameObject[] _upSector;
    [SerializeField] private GameObject[] _downSector;

    [SerializeField] private Vector2 _leftSectorPoint;
    [SerializeField] private Vector2 _rightSectorPoint;
    [SerializeField] private Vector2 _upSectorPoint;
    [SerializeField] private Vector2 _downSectorPoint;

    [SerializeField] private EnemySpawner _enemySpawner;

    private void Awake()
    {
        GameObject left = Instantiate(_leftSector[Random.Range(0, _leftSector.Length)], _leftSectorPoint, Quaternion.identity);
        GameObject right = Instantiate(_rightSector[Random.Range(0, _rightSector.Length)], _rightSectorPoint, Quaternion.identity);
        GameObject up = Instantiate(_upSector[Random.Range(0, _upSector.Length)], _upSectorPoint, Quaternion.identity);
        GameObject down = Instantiate(_downSector[Random.Range(0, _downSector.Length)], _downSectorPoint, Quaternion.identity);

        TransferPoints(left, right, up, down);
    }

    private void TransferPoints(GameObject Left, GameObject Right, GameObject Up, GameObject Down)
    {
        Transform[] leftPoints = Left.GetComponentsInChildren<Transform>();
        Transform[] rightPoints = Right.GetComponentsInChildren<Transform>();
        Transform[] upPoints = Up.GetComponentsInChildren<Transform>();
        Transform[] downPoints = Down.GetComponentsInChildren<Transform>();

        foreach (var point in leftPoints)
        {
            if (point.CompareTag("Spawn"))
            {
                _enemySpawner.PointsAdd((Vector2)point.position);
            }
        }
        foreach (var point in rightPoints)
        {
            if (point.CompareTag("Spawn"))
            {
                _enemySpawner.PointsAdd((Vector2)point.position);
            }
        }
        foreach (var point in upPoints)
        {
            if (point.CompareTag("Spawn"))
            {
                _enemySpawner.PointsAdd((Vector2)point.position);
            }
        }
        foreach (var point in downPoints)
        {
            if (point.CompareTag("Spawn"))
            {
                _enemySpawner.PointsAdd((Vector2)point.position);
            }
        }
    }
}
