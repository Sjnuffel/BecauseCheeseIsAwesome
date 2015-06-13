using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class GameStateManager : IGameLoopObject
{
    protected Dictionary<string, IGameLoopObject> gameStates;
    protected IGameLoopObject currentGameState;

    public GameStateManager()
    {
        gameStates = new Dictionary<string, IGameLoopObject>();
        currentGameState = null;
    }

    // Method to Add a new GameState to the Dictionary.
    // How to use: GameStateManager.AddGameState("string_name", string_value")
    public void AddGameState(string name, IGameLoopObject state)
    {
        gameStates[name] = state;
    }

    // Method to Get the GameState from Dictionary.
    // How to use: GameStateManager.GetGameState("string_name, "string_value")
    public IGameLoopObject GetGameState(string name)
    {
        return gameStates[name];
    }

    // Method to SwitchTo another GameState.
    // How to use: GameStateManager.SwitchTo("string_name", "string_value")
    public void SwitchTo(string name)
    {
        if (gameStates.ContainsKey(name))
            currentGameState = gameStates[name];
    }

    public IGameLoopObject CurrentGameState
    {
        get
        {
            return currentGameState;
        }
    }

    public void HandleInput(InputHelper inputHelper)
    {
        if (currentGameState != null)
            currentGameState.HandleInput(inputHelper);
    }

    public void Update(GameTime gameTime)
    {
        if (currentGameState != null)
            currentGameState.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (currentGameState != null)
            currentGameState.Draw(gameTime, spriteBatch);
    }

    public void Reset()
    {
        if (currentGameState != null)
            currentGameState.Reset();
    }
}