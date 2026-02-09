using UnityEngine;
using UnityEngine.Rendering;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused
}
public class GameStateManager : MonoBehaviour
{
    [Header("Read Only")]
    [SerializeField] private string _currentActiveState;
    [SerializeField]private string _previousActiveState;

    public GameState _currentState { get; private set; }
    public GameState _previousState { get; private set; }
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

                //do main menu stuff here

                break;

            case GameState.Gameplay:
                Debug.Log("Gamestate changed to Gameplay");

                //Do gameplay stuff here

                break;

            case GameState.Paused:
                Debug.Log("Gamestate changed to Paused");

                //do paused stuff here

                break;

        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetState(GameState.Gameplay);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            if(_currentState != GameState.Paused)
            {
                SetState(GameState.Paused);
            }
            else
            {
                SetState(_previousState);
            }
        }
    }
}
