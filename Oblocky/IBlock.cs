namespace Oblocky
{
    interface IBlock
    {
        IBlock NextBlock { get; set; }

        void Execute();
    }
}
