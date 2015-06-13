using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class GameObject : IGameLoopObject
{
    protected GameObject parent;
    protected Vector2 position, velocity;
    protected int layer;
    protected string id;
    protected bool visible;

    public GameObject(int layer = 0, string id = "")
    {
        this.layer = layer;
        this.id = id;
        this.position = Vector2.Zero;
        this.velocity = Vector2.Zero;
        this.visible = true;
    }

    public virtual void HandleInput(InputHelper inputHelper)
    {
    }

    public virtual void Update(GameTime gameTime)
    {
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
    }

    public virtual void Reset()
    {
        visible = true;
    }

    // Getters and Setters
    public virtual Vector2 Position                     // Position
    {
        get { return position; }
        set { position = value; }
    }

    public virtual Vector2 Velocity                     // Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public virtual Vector2 GlobalPosition               // GlobalPosition
    {
        get
        {
            if (parent != null)
                return parent.GlobalPosition + this.Position;
            else
                return this.Position;
        }
    }

    public GameObject Root                              // Root
    {
        get
        {
            if (parent != null)
                return parent.Root;
            else
                return this;
        }
    }

    public GameObjectList GameWorld                     // GameWorld
    {
        get
        {
            return Root as GameObjectList;
        }
    }

    public virtual int Layer                            // Graphics Layer
    {
        get { return layer; }
        set { layer = value; }
    }

    public virtual GameObject Parent                    // Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    public string ID                                    // Sprite ID tag
    {
        get { return id; }
    }

    public bool Visible                                 // Visible Sprite yes/no
    {
        get { return visible; }
        set { visible = value; }
    }

    public virtual Rectangle BoundingBox                // Dunno yet.
    {
        get
        {
            return new Rectangle((int)GlobalPosition.X, (int)GlobalPosition.Y, 0, 0);
        }
    }
}
