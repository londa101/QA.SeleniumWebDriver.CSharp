namespace QA.Core.Contracts
{
    /// <summary>
    /// The Page interface.
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// Gets the title of the page.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the url of the page.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Navigates to the page.
        /// </summary>
        void NavigateTo();
    }
}
