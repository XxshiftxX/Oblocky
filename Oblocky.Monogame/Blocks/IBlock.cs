namespace Oblocky.Monogame
{
    public abstract class IBlock : IDrawable
    {
        public abstract IBlock NextBlock {
            get;
            set;
        }

        public abstract void Execute();
    }
}