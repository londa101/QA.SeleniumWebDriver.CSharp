namespace QA.Core.Contracts
{
    public interface IPage
    {
        void NavigateTo();

        string Title { get; }

        string Url { get; }
    }
}
