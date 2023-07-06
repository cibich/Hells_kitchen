using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] private CamFlow _camera;
    [SerializeField] private float _playerShiftX;
    [SerializeField] private float _playerShiftY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftRoom"))
        {
            _camera.CamShiftLeft();
            _playerController.PlayerShiftLeft(_playerShiftX);
        }

        if (collision.CompareTag("RightRoom"))
        {
            _camera.CamShiftRight();
            _playerController.PlayerShiftRight(_playerShiftX);
        }

        if (collision.CompareTag("DownRoom"))
        {
            _camera.CamShiftDown();
            _playerController.PlayerShiftDown(_playerShiftY);
        }

        if (collision.CompareTag("UpRoom"))
        {
            _camera.CamShiftUp();
            _playerController.PlayerShiftUp(_playerShiftY);
        }

    }

}
