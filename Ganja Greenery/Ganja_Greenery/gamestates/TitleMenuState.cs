using Microsoft.Xna.Framework;

class TitleMenuState : GameObjectList
{
    protected Button playButton, optionButton, helpButton;

    public TitleMenuState()
    {
        //Load the title screen
        //NOTE TO SELF: PLACEHOLDER SPRITES
        SpriteGameObject title = new SpriteGameObject("sprites/spr_titlescreen", 0, "background");
        this.Add(title);

        //Add a PLAY button
        //NOTE TO SELF: PLACEHOLDER SPRITES
        playButton = new Button("sprites/spr_button_play");
        playButton.Position = new Vector2(415, 540);
        this.Add(playButton);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (playButton.ButtonPressed)
            GanjaGame.GameStateManager.SwitchTo("levelmenu");
    }
}