namespace Projekt_Auftragsverwaltung.Gui
{
    public class FormController : Form
    {
        
        public void ClearTextBoxes()
        {
            foreach (Control controller in Controls)
            {
                if (controller is TextBox)
                {
                    ((TextBox)controller).Clear();
                }
            }
        }

        public void CloseForm()
        {
            Hide();
            ClearTextBoxes();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(278, 244);
            Name = "FormController";
            ResumeLayout(false);

        }
    }

}
