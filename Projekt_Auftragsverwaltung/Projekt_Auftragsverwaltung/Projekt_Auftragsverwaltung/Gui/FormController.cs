namespace Projekt_Auftragsverwaltung.Gui
{
    public class FormController : Form
    {
        
        public void ClearTextBoxes()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
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
