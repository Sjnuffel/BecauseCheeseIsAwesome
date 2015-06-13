using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class GanjaGame : Game
{
    protected GraphicsDeviceManager graphics;
    protected SpriteBatch spriteBatch;
    protected InputHelper inputHelper;
    protected Matrix spriteScale;
    protected static Point screen;

    protected static AssetManager assetManager;
    protected static GameSettingsManager gameSettingsManager;
    protected static GameStateManager gameStateManager;
    protected static Random random;

    // Main loop start.
    static void Main()
    {
        GanjaGame ganjaGame = new GanjaGame();
        ganjaGame.Run();
    }

    public GanjaGame()
    {
        // Point/Direct to GanjaContent root directory
        Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
        graphics = new GraphicsDeviceManager(this);

        // Start all the important stuff.
        inputHelper = new InputHelper();
        spriteScale = Matrix.CreateScale(1, 1, 1);
        random = new Random();
        assetManager = new AssetManager(Content);
        gameStateManager = new GameStateManager();
        gameSettingsManager = new GameSettingsManager();

        gameSettingsManager.SetValue("hints", "on");
    }


    // Fullscreen mode and scaling properly.
    public void SetFullscreen(bool fullscreen = true)
    {
        float scalex = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (float)screen.X;
        float scaley = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (float)screen.Y;
        float finalscale = 1f;

        if (!fullscreen)
        {
            if (scalex < 1f || scaley < 1f)
                finalscale = Math.Min(scalex, scaley);
        }
        else
        {
            finalscale = scalex;
            if (Math.Abs(1 - scaley) < Math.Abs(1 - scalex))
                finalscale = scaley;
        }

            graphics.PreferredBackBufferWidth = (int)(finalscale * screen.X);
            graphics.PreferredBackBufferHeight = (int)(finalscale * screen.Y);
            graphics.IsFullScreen = fullscreen;
            graphics.ApplyChanges();
            inputHelper.Scale = new Vector2((float)GraphicsDevice.Viewport.Width / screen.X,
                                            (float)GraphicsDevice.Viewport.Height / screen.Y);
            spriteScale = Matrix.CreateScale(inputHelper.Scale.X, inputHelper.Scale.Y, 1);
    }


    // Loading the sprites to be drawn.
    protected override void LoadContent()
    {
        base.LoadContent();
        spriteBatch = new SpriteBatch(GraphicsDevice);
        screen = new Point(1200, 900);
        this.SetFullscreen(false);

        gameStateManager.AddGameState("titleMenu", new TitleMenuState());
        gameStateManager.AddGameState("optionsMenu", new OptionsMenuState());
        gameStateManager.SwitchTo("titleMenu");
    }

    // Handles updates from classes like inputHelper.
    protected override void Update(GameTime gameTime)
    {
        inputHelper.Update();
        if (inputHelper.KeyPressed(Keys.Escape))
            this.Exit();
        if (inputHelper.KeyPressed(Keys.F5))
            SetFullscreen(!graphics.IsFullScreen);
    }

    // Call gameWorld.Draw command to actually draw on screen.
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);
        gameStateManager.Draw(gameTime, spriteBatch);
        spriteBatch.End();
    }

    public static Random Random
    {
        get { return random; }
    }

    public static Point Screen
    {
        get { return screen; }
        set { screen = value; }
    }

    public static AssetManager AssetManager
    {
        get { return assetManager; }
    }

    public static GameSettingsManager GameSettingsManager
    {
        get { return GameSettingsManager; }
    }

    public static GameStateManager GameStateManager
    {
        get { return gameStateManager; }
    }

}