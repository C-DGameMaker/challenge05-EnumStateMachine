using UnityEngine;
using UnityEngine.Rendering;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused,
    Settings,
    GameOver
}
public class GameStateManager : MonoBehaviour
{
    [Header("Read Only")]
    [SerializeField] private string _currentActiveState;
    [SerializeField]private string _previousActiveState;

    public GameState _currentState { get; private set; }
    public GameState _previousState { get; private set; }
    [SerializeField] UIManager _uIManager;
    private void Start()
    {
        SetState(GameState.Init);
    }

    

    public void SetState(GameState newState)
    {
        _previousState = _currentState;
        _currentState = newState;

        _previousActiveState = _previousState.ToString();
        _currentActiveState = _currentState.ToString();

        OnGameStateChanged(prevouisState: _previousState, newState: _currentState);
    }

    private void OnGameStateChanged(GameState prevouisState, GameState newState)
    {
        switch(newState)
        {
            default:
                break;

            case GameState.None:
                Debug.Log("Why are you here?");
                break;

            case GameState.Init:
                Debug.Log("Gamestate changed to init");

                // do init stuff jerer

                SetState(newState: GameState.MainMenu);
                break;

            case GameState.MainMenu:
                Debug.Log("Gamestate changed to Main Menu");
                Time.timeScale = 1f;
                _uIManager.ShowMainMenuUI();
                //do main menu stuff here

                break;

            case GameState.Gameplay:
                Debug.Log("Gamestate changed to Gameplay");
                _uIManager.ShowGameplayUI();
                Time.timeScale = 1f;
                //Do gameplay stuff here

                break;

            case GameState.Paused:
                Debug.Log("Gamestate changed to Paused");
                Time.timeScale = 0f;
                _uIManager.ShowPausedUI();
                //do paused stuff here

                break;

            case GameState.Settings:
                Debug.Log("Gamestate changed to Paused");
                Time.timeScale = 1f;
                _uIManager.ShowSettingsUI();
                //do paused stuff here

                break;

            case GameState.GameOver:
                Debug.Log("Gamestate changed to Paused");
                Time.timeScale = 1f;
                _uIManager.ShowGameOverUI();
                //do paused stuff here

                break;

        }
    }

    public void StartGame()
    {
        SetState(newState: GameState.Gameplay);
    }

    public void Resume()
    {
        SetState(newState: _previousState);

        if(_currentState == GameState.Paused)
        {
            _previousState = GameState.Gameplay;
        }
    }

    public void MainMenu()
    {
        SetState(newState: GameState.MainMenu);
    }

    public void Settings()
    {
        SetState(newState: GameState.Settings);
    }

    public void GameOver()
    {
        if(_currentState == GameState.Gameplay)
        {
            if (_currentState == GameState.GameOver) return;
            SetState(newState: GameState.GameOver);
        }
    }
       
    

    public void TogglePause()
    {
        if (_currentState == GameState.Gameplay)
        {
            if (_currentState == GameState.Paused) return;
                SetState(newState: GameState.Paused);
        }
        else if (_currentState == GameState.Paused)
        {
            if (_currentState == GameState.Gameplay) return;
                SetState(newState: GameState.Gameplay);
        }

        
    }
}
