﻿using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_winForm.Forms
{
    public partial class frmAddContact : Form
    {
        private readonly ContactService contactService;
        public frmAddContact()
        {
            InitializeComponent();
            contactService = new ContactService();
        }

        private void frmAddContact_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = contactService.AddNewContact(new BLL.Dto.AddNewContactDto
            {
                Company = txtCompany.Text,
                Description = txtDescription.Text,
                LastName = txtLastName.Text,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text
            });
            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
