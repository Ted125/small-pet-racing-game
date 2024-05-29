using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField]
    private Button _raceButton;

    private void Start()
    {
        _raceButton.onClick.AddListener(LoadRaceScene);
    }

    private void LoadRaceScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}