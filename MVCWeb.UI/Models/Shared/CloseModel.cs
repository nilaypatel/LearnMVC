namespace MVCWeb.UI.Models.Shared
{
    public class CloseModel
    {
        public string Url { get; set; }

        public CloseAction CloseAction { get; set; }
    }

    public enum CloseAction
    {
        Close,
        CloseAndRedirect,
        CloseAndReload
    }
}