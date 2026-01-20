using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance { get; private set; }

    private float deathAmount = 0;

    public TextMeshProUGUI deathText;

    private bool isPauzed = false;

    [SerializeField] private Button pauzeButton;
    [SerializeField] private Button continueButton;

    [SerializeField] private TextMeshProUGUI paintAmountText;
    private float paintAmount;
    [SerializeField] private GameObject paint;
    private bool isPaintSelected = false;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathAmount++;
        deathText.text = "Deaths: " + deathAmount.ToString();
        PaintSet(0);
    }

    public void Pauze()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void TogglePauze(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!isPauzed)
            {
                pauzeButton.onClick.Invoke();
            }
            else
            {
                continueButton.onClick.Invoke();
            }
            isPauzed = !isPauzed;
        }
    }
    public void PaintCollect()
    {
        if (paintAmount == 0)
        {
            paint.SetActive(true);
        }
        paintAmount++;
        paintAmountText.text = paintAmount.ToString();
    }
    public void PaintDelete()
    {
        paintAmount--;
        paintAmountText.text = paintAmount.ToString();
        if (paintAmount == 0)
        {
            paint.SetActive(false);
        }
    }
    public void PaintSet(float amount)
    {
        paintAmount = amount;
        paintAmountText.text = paintAmount.ToString();
        if (paintAmount == 0)
        {
            paint.SetActive(false);
        }
    }
    public void PaintSelect()
    {
        if (paintAmount > 0)
        {
            Debug.Log("isclicked");
            isPaintSelected = !isPaintSelected;
        }
        
    }
    public void Paint(GameObject gameobject)
    {
        if (isPaintSelected)
        {
            PaintDelete();
            isPaintSelected = false;
            Destroy(gameobject);
        }
        
    }
}
