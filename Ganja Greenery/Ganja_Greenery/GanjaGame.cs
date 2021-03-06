﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class GanjaGame : GameEnvironment
{
    // Main loop start
    static void Main()
    {
        GanjaGame ganjaGame = new GanjaGame();
        ganjaGame.Run();
    }

    // Direct to Content directory
    public GanjaGame()
    {
        Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
        GameSettingsManager.SetValue("hints", "on");
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        screen = new Point(1200, 900);
        this.SetFullScreen(false);

        // Add the game states
        gameStateManager.AddGameState("titleMenuState", new TitleMenuState());
        gameStateManager.AddGameState("optionsMenuState", new OptionsMenuState());

        gameStateManager.SwitchTo("titleMenuState");

        // Add code for music here.

    }
}