namespace Morabaraba
{
    /// <summary>
    /// The Morabaraba Printing interface
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Prints relevant game information to the user
        /// </summary>
        void Print();
        
        /// <summary>
        /// Gets or sets error output
        /// </summary>
        string Error { get; set; }

        /// <summary>
        /// Gets or sets request output
        /// </summary>
        string Request { get; set; }
    }
}