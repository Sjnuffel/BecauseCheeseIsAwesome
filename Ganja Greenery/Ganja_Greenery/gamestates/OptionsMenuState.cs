using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class OptionsMenuState : GameObjectList
{
    protected Button backButton;
    protected Slider musicVolumeSlider;
    protected OnOffButton onOffButton;

    public OptionsMenuState()
    {
        // add a background
        SpriteGameObject background = new SpriteGameObject("Sprites/spr_background_options", 0, "background");
        this.Add(background);

        // add a slider for music volume
        TextGameObject bgmusictext = new TextGameObject("Fonts/MenuFont", 1);
        bgmusictext.Text = "Music Volume";
        bgmusictext.Color = Color.DarkBlue;
        bgmusictext.Position = new Vector2(150, 480);
        this.Add(bgmusictext);
        musicVolumeSlider = new Slider("Sprites/spr_slider_bar", "Sprites/spr_slider_button", 1);
        musicVolumeSlider.Position = new Vector2(650, 500);
        this.Add(musicVolumeSlider);
        musicVolumeSlider.Value = MediaPlayer.Volume;

        // add a back button
        backButton = new Button("sprites/spr_button_back");
        backButton.Position = new Vector2(415, 720);
        this.Add(backButton);

    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (backButton.ButtonPressed)
            GameEnvironment.GameStateManager.SwitchTo("titleMenuState");
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        MediaPlayer.Volume = musicVolumeSlider.Value;
    }
}
