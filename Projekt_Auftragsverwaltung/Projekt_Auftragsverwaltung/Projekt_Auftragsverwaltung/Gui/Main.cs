using System.Reflection.Metadata;
using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung

{
    public partial class Main : FormController
    {
        private Form EditGuiArticleGroup;
        private Form EditGuiCustomer;
        private Form EditGuiArticle;
        private Form EditGuiOrder;
        private Form EditGuiPosition;


        //public Entity Article


        public Main()
        {
            InitializeComponent();
            this.EditGuiArticleGroup = new MainEditArticleGroup();
            this.EditGuiCustomer = new MainEditCustomer();
            this.EditGuiArticle = new MainEditArticle(this);
            this.EditGuiPosition = new MainEditPosition();
            this.EditGuiOrder = new MainEditOrder();

        }


        private void CmdCreateArticleGroup_Click(Object sender, EventArgs e)
        {
            this.EditGuiArticleGroup.ShowDialog();

        }

        private void CmdCreateCustomer_Click(object sender, EventArgs e)
        {
            this.EditGuiCustomer.Location = new Point(15,15);
            this.EditGuiCustomer.ShowDialog();
        }

        private void CmdCreateArticle_Click(object sender, EventArgs e)
        {
            this.EditGuiArticle.ShowDialog();

        }

        private void CmdCreateOrder_Click(object sender, EventArgs e)
        {
            this.EditGuiOrder.ShowDialog();
        }

        private void CmdCreatePosition_Click(object sender, EventArgs e)
        {
            this.EditGuiPosition.ShowDialog();
        }


        private void CmdEditArticleGroup_Click(Object sender, EventArgs e)
        {
            this.EditGuiArticleGroup.ShowDialog();

        }

        private void CmdEditCustomer_Click(object sender, EventArgs e)
        {
            this.EditGuiCustomer.ShowDialog();
        }

        private void CmdEditArticle_Click(object sender, EventArgs e)
        {
            this.EditGuiArticle.ShowDialog();
        }


        private void CmdEditPosition_Click(object sender, EventArgs e)
        {
            this.EditGuiPosition.ShowDialog();
        }

        private void CmdEditOrder_Click(object sender, EventArgs e)
        {
            this.EditGuiOrder.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void UpdateArticleGroup()
        {
            // Artikelgruppe Liste updaten.


        }
    }
}