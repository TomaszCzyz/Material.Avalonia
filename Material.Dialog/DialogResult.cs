using Material.Dialog.Interfaces;

namespace Material.Dialog
{
    public class DialogResult : IDialogResult
    {
        /// <summary>
        /// Constant none result.
        /// </summary>
        public static DialogResult NoResult { get; private set; } = new DialogResult { _result = "none" };


        public DialogResult()
        {
        }

        public DialogResult(string result)
        {
            _result = result;
        }


        private string _result = string.Empty;

        public virtual string GetResult => _result;
    }
}
