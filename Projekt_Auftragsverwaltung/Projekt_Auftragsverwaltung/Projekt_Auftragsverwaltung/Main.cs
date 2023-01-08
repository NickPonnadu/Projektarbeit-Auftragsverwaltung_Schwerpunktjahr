namespace Projekt_Auftragsverwaltung

{
    public partial class Main : Form
    {
        Form EditGuiArticleGroup;
        Form EditGuiCustomer;
        Form EditGuiArticle;
        Form EditGuiOrder;
        Form EditGuiPosition;

        public Main()
        {
            InitializeComponent();
            EditGuiArticleGroup = new MainEditArticleGroup();
            EditGuiCustomer = new MainEditCustomer();
            EditGuiArticle = new MainEditCustomer();
            EditGuiPosition = new MainEditCustomer();
        }

        private void CmdCreateArticleGroup_Click(Object sender, EventArgs e)
        {
            EditGuiArticleGroup.ShowDialog();
           
        }

        private void CmdCreateCustomer_Click(object sender, EventArgs e)
        {
            EditGuiCustomer.ShowDialog();   
        }

        private void CmdCreateArticle_Click(object sender, EventArgs e)
        {
            EditGuiArticle.ShowDialog();
        }

        private void CmdCreateOrder_Click(object sender, EventArgs e)
        {
            EditGuiOrder.ShowDialog();
        }

        private void CmdCreatePosition_Click(object sender, EventArgs e)
        {
            EditGuiPosition.ShowDialog();
        }



        private void CmdEditArticleGroup_Click(Object sender, EventArgs e)
        {
            EditGuiArticleGroup.ShowDialog();

        }

        private void CmdEditCustomer_Click(object sender, EventArgs e)
        {
            EditGuiCustomer.ShowDialog();
        }

        private void CmdEditArticle_Click(object sender, EventArgs e)
        {
            EditGuiArticle.ShowDialog();
        }

       
        private void CmdEditPosition_Click(object sender, EventArgs e)
        {
            EditGuiPosition.ShowDialog();
        }

        private void CmdEditOrder_Click(object sender, EventArgs e)
        {
            EditGuiOrder.ShowDialog();
        }
    }
}