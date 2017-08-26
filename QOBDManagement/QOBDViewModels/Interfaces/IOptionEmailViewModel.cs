using QOBDCommon.Classes;
using QOBDModels.Classes;
using QOBDModels.Command;

namespace QOBDViewModels.Interfaces
{
    public interface IOptionEmailViewModel
    {
        InfoFileWriter BillEmailFile { get; set; }
        BusinessLogic Bl { get; }
        ButtonCommand<string> DeleteCommand { get; set; }
        InfoFileWriter OrderConfirmationEmailFile { get; set; }
        InfoFileWriter QuoteEmailFile { get; set; }
        InfoFileWriter ReminderOneEmailFile { get; set; }
        InfoFileWriter ReminderTwoEmailFile { get; set; }
        string Title { get; set; }
        ButtonCommand<string> UpdateCommand { get; set; }

        void Dispose();
        void load();
    }
}