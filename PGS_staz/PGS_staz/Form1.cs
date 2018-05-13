using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGS_staz
{
    public partial class Form1 : Form
    {
        List<TableLayoutPanel> panelsList;
        public Form1()
        {
            InitializeComponent();
            panelsList = new List<TableLayoutPanel> {
            this.GreetingPanel,
            this.NamePanel,
            this.SurnamePanel,
            this.AddressPanel,
            this.PhoneNumberPanel,
            this.EndPanel};
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            int index = CurrentPanelIndex();
            panelsList[index].Visible = false;
            panelsList[index + 1].Visible = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            int index = CurrentPanelIndex();
            panelsList[index].Visible = false;
            panelsList[index - 1].Visible = true;

        }

        private int CurrentPanelIndex()
        {
            return panelsList.Select((panel, index) => new { panel, index }).First(x => x.panel.Visible == true).index;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int index = CurrentPanelIndex();
            TableLayoutPanel buttonPanel = panelsList[index].Controls.OfType<TableLayoutPanel>().FirstOrDefault();
            Button continueButton = buttonPanel.Controls.OfType<Button>().FirstOrDefault(x => x.Name.Contains("ContinueButton"));
            continueButton.Enabled = true; 
            
        }

        private void EndPanel_VisibleChanged(object sender, EventArgs e)
        {
            NameShowTextBox.Text = NameTextBox.Text;
            SurnameShowTextBox.Text = SurnameTextBox.Text;
            PhoneNumberShowTextBox.Text = PhoneNumberTextBox.Text;
            AddressShowTextBox.Text = AddressTextBox.Text; 

        }
    }
}
