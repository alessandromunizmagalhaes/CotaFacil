using SAPbouiCOM;

namespace CotaFacil
{
    public class FormOfertaDeCompra : SAPHelper.Form
    {
        public override void OnBeforeFormOpen(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            Form form = Program._sBOApplication.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);

            const string refItemId = "2";
            const string btnCotarId = "btnCotar";

            Item refItem = form.Items.Item(refItemId);
            Item btnCotar = form.Items.Add(btnCotarId, BoFormItemTypes.it_BUTTON);

            btnCotar.FromPane = 0;
            btnCotar.ToPane = 0;
            btnCotar.Top = refItem.Top;
            btnCotar.Left = refItem.Left + (refItem.Width + 20);
            btnCotar.Width = refItem.Width + 50;

            ((Button)btnCotar.Specific).Caption = "Cotar Online";
        }
    }
}
