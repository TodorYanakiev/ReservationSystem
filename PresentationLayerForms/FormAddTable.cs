using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Services;

namespace PresentationLayerForms
{
    public partial class FormAddTable : Form
    {
        private readonly RestaurantTableService restaurantTableService;
        public FormAddTable()
        {
            restaurantTableService = new RestaurantTableService(new RestaurantDbContext());
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            RestaurantTable table = new RestaurantTable();
            table.CreatedAt = DateTime.Now;
            try
            {
                table.Number = int.Parse(textBoxTableNumber.Text);
            }
            catch
            {
                MessageBox.Show("Въведете неизползвано число за номер на масата.");
                return;
            }
            if (radioBtnStandart.Checked)
                table.Type = "standard";
            else if (radioButtonVIP.Checked)
                table.Type = "vip";
            else if (radioButtonOutdoor.Checked)
                table.Type = "outdoor";
            else
            {
                MessageBox.Show("Видът на масата е задължителен.");
                return;
            }
            table.Description = richTextBoxTableDescription.Text;

            restaurantTableService.AddTable(table);

            MessageBox.Show("Успешно добавихте нова маса.");
            clearForm();
        }

        private void clearForm()
        {
            textBoxTableNumber.Clear();
            radioBtnStandart.Checked = false;
            radioButtonVIP.Checked = false;
            radioButtonOutdoor.Checked = false;
            richTextBoxTableDescription.Clear();
        }
    }
}
