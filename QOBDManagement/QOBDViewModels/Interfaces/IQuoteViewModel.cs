using QOBDCommon.Classes;
using QOBDModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDViewModels.Interfaces
{
    public interface IQuoteViewModel
    {
        ItemModel ItemModel { get; set; }
        string Title { get; set; }
        bool IsCurrentPage { get; set; }
        BusinessLogic Bl { get; }
        string MissingCLientMessage { get; set; }
        OrderModel SelectedQuoteModel { get; set; }
        IOrderDetailViewModel QuoteDetailViewModel { get; set; }
        List<OrderModel> QuoteModelList { get; set; }
        ClientModel SelectedClient { get; set; }
        string BoxVisibility { get;}

        //----------------------------[ Commands ]------------------

        QOBDModels.Command.ButtonCommand<string> NavigCommand { get; set; }
        QOBDModels.Command.ButtonCommand<OrderModel> GetCurrentCommandCommand { get; set; }
        QOBDModels.Command.ButtonCommand<string> ValidCartToQuoteCommand { get; set; }
        QOBDModels.Command.ButtonCommand<OrderModel> DeleteCommand { get; set; }
        QOBDModels.Command.ButtonCommand<OrderModel> GetQuoteForUpdateCommand { get; set; }

        void executeNavig(string obj);
        void loadQuotations();
        void Dispose();
    }
}
