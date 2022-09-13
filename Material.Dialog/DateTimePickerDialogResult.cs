using System;
using Material.Dialog.Interfaces;

namespace Material.Dialog
{
    public class DateTimePickerDialogResult : IDialogResult
    {
        public DateTimePickerDialogResult()
        {
            Result = string.Empty;
        }

        public DateTimePickerDialogResult(string result, TimeSpan time)
        {
            Result = result;
            _timeSpan = time;
        }

        public DateTimePickerDialogResult(string result, DateTime date)
        {
            Result = result;
            DateTime = date;
        }

        internal string Result;
        public string GetResult => Result;

        // ReSharper disable once InconsistentNaming
        internal TimeSpan _timeSpan;

        /// <summary>
        /// Get results of TimePicker.
        /// </summary>
        public TimeSpan GetTimeSpan() => _timeSpan;

        internal DateTime DateTime;

        /// <summary>
        /// Get result of DatePicker.
        /// </summary>
        public DateTime GetDate() => DateTime;
    }
}
