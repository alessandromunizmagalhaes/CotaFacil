using SAPbouiCOM;
using SAPHelper;
using System;
using System.Collections.Generic;

namespace CotaFacil
{
    static class Program
    {
        private static string _addonName = "Cota Fácil";
        private static string _startupath = System.Windows.Forms.Application.StartupPath;
        public static Application _sBOApplication;
        public static SAPbobsCOM.Company _company;

        [STAThread]
        static void Main()
        {
            ConectarComSAP();

            // CriarEstruturaDeDados();

            // CriarMenus();

            DeclararEventos();

            Dialogs.Success(":: " + _addonName + " :: Iniciado.");

            // deixa a aplicação ativa
            System.Windows.Forms.Application.Run();
        }

        private static void ConectarComSAP()
        {
            SAPConnection.SBOApplicationHandler applicationHandler = null;
            applicationHandler += Dialogs.RecebeSBOApplication;
            applicationHandler += Menu.RecebeSBOApplication;
            applicationHandler += applicationParam => _sBOApplication = applicationParam;

            SAPConnection.CompanyHandler companyHandler = null;
            companyHandler += companyParam => _company = companyParam;
            companyHandler += Database.RecebeCompany;
            try
            {
                SAPConnection.Connect(applicationHandler, companyHandler);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                System.Windows.Forms.Application.Exit();
            }
        }

        private static void CriarEstruturaDeDados()
        {
            Dialogs.Info(":: " + _addonName + " :: Criando tabelas e estruturas de dados ...");

            //...
        }

        private static void CriarMenus()
        {
            Dialogs.Info(":: " + _addonName + " :: Criando menus ...");

            try
            {
                RemoverMenu();

                Menu.CriarMenus(_startupath + @"/criar_menus.xml");
            }
            catch (Exception e)
            {
                Dialogs.PopupError("Erro ao inserir menus.\nErro: " + e.Message);
            }
        }

        private static void RemoverMenu()
        {
            Menu.RemoverMenus(_startupath + @"/remover_menus.xml");
        }

        private static void DeclararEventos()
        {
            FormEvents.DeclararEventos(BoEventTypes.et_FORM_LOAD, new Dictionary<string, SAPHelper.Form>()
            {
                { ((int)FormTypes.OfertaDeCompra).ToString(), new FormOfertaDeCompra() },
                { ((int)FormTypes.PedidoDeVenda).ToString(), new FormPedidoDeVenda() },
                { ((int)FormTypes.NotaFiscalDeSaida).ToString(), new FormNotaFiscalDeSaida() },
            });

            _sBOApplication.AppEvent += AppEvent;
            _sBOApplication.ItemEvent += FormEvents.ItemEvent;
        }

        #region :: Declaração Eventos

        private static void AppEvent(BoAppEventTypes EventType)
        {
            if (EventType == BoAppEventTypes.aet_ShutDown)
            {
                RemoverMenu();
            }
        }

        #endregion
    }
}
