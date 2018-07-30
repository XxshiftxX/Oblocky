namespace Oblocky.Monogame
{
    public abstract class IBlock : IDrawable
    {
        public IBlock NextBlock { get; set; }

        public abstract void Execute();
    }
}