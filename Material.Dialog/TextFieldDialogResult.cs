namespace Material.Dialog
{
    public class TextFieldDialogResult : DialogResult
    {
        public TextFieldDialogResult()
        {
        }

        public TextFieldDialogResult(string result, TextFieldResult[] fieldsResult)
        {
            Result = result;
            FieldsResult = fieldsResult;
        }

        internal string Result = string.Empty;
        public override string GetResult => Result;

        internal TextFieldResult[] FieldsResult;
        public TextFieldResult[] GetFieldsResult() => FieldsResult;
    }
}
