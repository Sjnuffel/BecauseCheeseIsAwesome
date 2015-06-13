using Microsoft.Xna.Framework;

class Button : SpriteGameObject
{
    protected bool buttonpressed;

    public Button(string imageAsset, int layer = 0, string id = "")
        : base(imageAsset, layer, id)
    {
        buttonpressed = false;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        buttonpressed = inputHelper.MouseLeftButtonPressed() &&
            BoundingBox.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y);
    }

    public override void Reset()
    {
        base.Reset();
        buttonpressed = false;
    }

    public bool ButtonPressed
    {
        get { return buttonpressed; }
    }
}