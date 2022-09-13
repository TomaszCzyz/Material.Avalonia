using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Material.Dialog.Interfaces;
using Material.Dialog.ViewModels;

namespace Material.Dialog.Views
{
    public class DatePickerDialog : Window, IDialogWindowResult<DateTimePickerDialogResult>, IHasNegativeResult
    {
        public DateTimePickerDialogResult Result { get; set; }

        public DatePickerDialog()
        {
            Result = new DateTimePickerDialogResult();

            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif
        }

        public void AttachViewModel(DatePickerDialogViewModel vm)
        {
            DataContext = vm;
        }

        public DateTimePickerDialogResult GetResult()
        {
            return Result;
        }

        public void SetNegativeResult(DialogResult result)
        {
            Result.Result = result.GetResult;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
