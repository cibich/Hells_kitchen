using UnityEngine;
using UnityEngine.UI;

public class Ingridients : MonoBehaviour
{
    public bool Meat;
    public bool Pasta;
    public bool Cheese;
    public bool Broccoli;
    public bool Wine;

    public bool _start;
    public float _startTime = 0f;

    [Header("UI")]
    [SerializeField] GameObject _questPanel;
    [SerializeField] GameObject _miniMap;
    [SerializeField] Toggle _meatToggle;
    [SerializeField] Toggle _passtaToggle;
    [SerializeField] Toggle _cheeseToggle;
    [SerializeField] Toggle _broccoliToggle;
    [SerializeField] Toggle _wineToggle;

    [SerializeField] Image _circleBar;
    [SerializeField] Image _circleBarDauther;

    private void Update()
    {
        ActivatePanel();
        Toggles();
        Cook(); 
        
    }

    public void Cooking()
    {
        if (Meat && Pasta && Cheese && Broccoli && Wine)
        {
            _start = true;
            Meat = false;
            Pasta = false;
            Cheese = false;
            Broccoli = false;
            Wine = false;

        }
    }

    private void Cook()
    {
        if (_start == true)
        {
            _circleBar.gameObject.SetActive(true);
            _startTime += Time.deltaTime / 15;
            _circleBarDauther.fillAmount = _startTime;


            if (_startTime > 1.1f)
            {
                _circleBar.gameObject.SetActive(false);
                _start = false;
                _startTime = 0;
            }
        }
    }

    private void ActivatePanel()
    {
        if (Input.GetKeyDown(KeyCode.I) && _questPanel.activeInHierarchy == false)
        {
            _questPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I) && _questPanel.activeInHierarchy == true)
        {
            _questPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.M) && _miniMap.activeInHierarchy == false)
        {
            _miniMap.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.M) && _miniMap.activeInHierarchy == true)
        {
            _miniMap.SetActive(false);
        }

    }
    private void Toggles()
    {
        _meatToggle.isOn = Meat;
        _passtaToggle.isOn = Pasta;
        _cheeseToggle.isOn = Cheese;
        _broccoliToggle.isOn = Broccoli;
        _wineToggle.isOn = Wine;
    }
}
