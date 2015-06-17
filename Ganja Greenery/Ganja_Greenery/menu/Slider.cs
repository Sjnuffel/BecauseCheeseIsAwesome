using Microsoft.Xna.Framework;

// Basic Slider class, to use in volume sliders for example.

class Slider : GameObjectList
{
    protected SpriteGameObject back, front;
    protected bool dragging;
    protected int leftmargin, rightmargin;

    public Slider(string sliderback, string sliderfront, int layer = 0, string id = "")
        :base(layer, id)
    {
        // Provide sprites for drawing        
        back = new SpriteGameObject(sliderback, 0);
        this.Add(back);

        front = new SpriteGameObject(sliderfront, 1);
        this.Add(front);

        leftmargin = 5;
        rightmargin = 7;

        dragging = false;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (inputHelper.MouseLeftButtonDown())
        {
            // If mouse is within bounding box AND dragging, move slider position)
            if (back.BoundingBox.Contains(new Point((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y)) || dragging)
            { 
                // Actual movement
                float newxpos = MathHelper.Clamp(inputHelper.MousePosition.X - back.GlobalPosition.X - front.Width / 2, back.Position.X + leftmargin, back.Position.X + back.Width - front.Width - rightmargin);
                front.Position = new Vector2(newxpos, front.Position.Y);
                dragging = true;
            }
        }
    }

    public float Value
    {
        get
        {
            return (front.Position.X - back.Position.X - leftmargin) / (back.Width - leftmargin - rightmargin - front.Width);
        }
        set
        {
            float newxpos = value * (back.Width - front.Width - leftmargin - rightmargin) + back.Position.X + leftmargin;
            front.Position = new Vector2(newxpos, front.Position.Y);
        }

    }
}
