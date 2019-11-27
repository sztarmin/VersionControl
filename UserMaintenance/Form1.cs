using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.FullName;
            btnAdd.Text = Resource1.Add;
            button1.Text = Resource1.wtf;
            button2.Text = Resource1.delbtn;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
            listUsers.SelectionMode = SelectionMode.MultiExtended;

            btnAdd.Click += BtnAdd_Click;
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = listUsers.SelectedIndices.Count-1; i>= 0; i--)
            {
                listUsers.Items.RemoveAt(listUsers.SelectedIndices[i]);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text
            };
            users.Add(u);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();
            String fn = saveFileDialog1.FileName;
            if (fn != "")
            {
                try
                {
                    StreamWriter sw = new StreamWriter(fn);
                    sw.WriteLine("id,name");
                    //using for as it's faster than foreach
                    for (int i = 0; i < users.Count; i++)
                    {
                        sw.WriteLine(users[i].ID + "," + users[i].FullName);
                    }

                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured: " + ex.Message);
                }
            }
        }
    }
}
