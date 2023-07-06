using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private float _speed;
    [SerializeField] private int _defaultHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private bool _isShield;
    [SerializeField] private float _shift;
    private float _horizontalInput, _verticalInput;

    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        EventManager.EnemyDied += EventManager_EnemyDied;
        _currentHealth = _defaultHealth;
    }

    private void EventManager_EnemyDied()
    {
        Debug.Log("Враг убит");
    }

    private void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown(1) && _isShield == false)
        {
            if (_horizontalInput < 0)
                PlayerShiftLeft(_shift);
            if (_horizontalInput > 0)
                PlayerShiftRight(_shift);
            if (_verticalInput > 0)
                PlayerShiftUp(_shift);
            if (_verticalInput < 0)
                PlayerShiftDown(_shift);
            StartCoroutine(Shield());
        }
    }

    private void Movement()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); _verticalInput = Input.GetAxis("Vertical");
        _playerRb.velocity = new Vector2(_horizontalInput * _speed, _verticalInput * _speed);

        MoveAnimation();
    }

    IEnumerator Shield()
    {
        _isShield = true;
        _spriteRenderer.color = Color.black;
        yield return new WaitForSeconds(0.5f);
        _spriteRenderer.color = Color.white;
        _isShield = false;
    }

    private void MoveAnimation()
    {
        if (_verticalInput != 0 || _horizontalInput != 0)
            _anim.SetBool("IsWalk", true);
        else
            _anim.SetBool("IsWalk", false);

        if (_horizontalInput < 0)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        _anim.SetFloat("Horizontal", _horizontalInput);
        _anim.SetFloat("Vertical", _verticalInput);
    }

    public void TakeDamage(int damage)
    {
        if (_isShield == false)
        {
            _currentHealth -= damage;
            EventManager.OnPlayerHurt(_currentHealth);
        }

        if (_currentHealth <= 0)
            SceneManager.LoadScene(0);
    }

    public void AddHealth(int hp)
    {
        _currentHealth += hp;
        EventManager.OnPlayerHurt(_currentHealth);

        if (_currentHealth > 10)
            _currentHealth=10;
    }

    public Vector3 PlayerShiftLeft(float shiftX)
    { return transform.position = new Vector2(transform.position.x - shiftX, transform.position.y); }
    public Vector3 PlayerShiftRight(float shiftX)
    { return transform.position = new Vector2(transform.position.x + shiftX, transform.position.y); }
    public Vector3 PlayerShiftUp(float shiftY)
    { return transform.position = new Vector2(transform.position.x, transform.position.y + shiftY); }
    public Vector3 PlayerShiftDown(float shiftY)
    { return transform.position = new Vector2(transform.position.x, transform.position.y - shiftY); }
}
