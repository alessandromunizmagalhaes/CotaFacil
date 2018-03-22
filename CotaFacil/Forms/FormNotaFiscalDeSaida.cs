using SAPbouiCOM;
using SAPHelper;

namespace CotaFacil
{
    public class FormNotaFiscalDeSaida : SAPHelper.Form
    {
        public override void OnBeforeFormOpen(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (Dialogs.Confirm("Deseja mesmo abrir essa tela?"))
            {
                Dialogs.Success("abrindo a tela...");
            }
            else
            {
                BubbleEvent = false;
            }
        }

        public override void OnBeforeClick(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
        }
    }
}
