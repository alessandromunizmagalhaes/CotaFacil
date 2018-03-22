using SAPbouiCOM;
using SAPHelper;
namespace CotaFacil
{
    public class FormPedidoDeVenda : SAPHelper.Form
    {
        public override void OnBeforeFormOpen(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            Dialogs.PopupSuccess("Opa, você abriu um pedido de venda!");
        }
    }
}
