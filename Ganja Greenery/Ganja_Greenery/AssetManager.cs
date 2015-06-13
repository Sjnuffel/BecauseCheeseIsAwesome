using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

public class AssetManager
{
    protected ContentManager contentManager;

    // Make AssetManager use Content as it's source folder
    public AssetManager(ContentManager Content)
    {
        this.contentManager = Content;
    }

    // Method to retrieve a sprite from the Content folder
    public Texture2D GetSprite(string assetName)
    {
        if (assetName == "")
            return null;
        return contentManager.Load<Texture2D>(assetName);
    }

    // Method to retrieve a sound from the Content folder
    public void PlaySound(string assetName)
    {
        SoundEffect snd = contentManager.Load<SoundEffect>(assetName);
        snd.Play();
    }

    // Method to retrieve a piece of music from the Content folder
    public void PlayMusic(string assetName, bool repeat = true)
    {
        MediaPlayer.IsRepeating = repeat;
        MediaPlayer.Play(contentManager.Load<Song>(assetName));
    }

    // Get/Set the content manager
    public ContentManager Content
    {
        get { return contentManager; }
    }
}