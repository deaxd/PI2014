using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vjezbe03_AndreaKljaic
{
    public partial class FrmGlavna : Form
    {
        public FrmGlavna()
        {
            InitializeComponent();
        }

        private void btnIzracunaj_Click(object sender, EventArgs e)
        {
            //Deklaracija lokalnih varijabli
            float polumjer = 0, povrsina = 0, opseg = 0;
            //Dohvaćanje vrijednosti iz TextBox kontrola u varijablu,
            //parsiranje automatski onemogućava i pojavu nenumeričkih vrijednosti
            float.TryParse(txtPolumjer.Text, out polumjer);
            //Onemogućavanje vrijednosti manjih od nule
            if (polumjer < 0) polumjer = 0;
            //Izračunavanje površine i opsega kruga.
            povrsina = polumjer * polumjer * (float)Math.PI;
            opseg = 2 * polumjer * (float)Math.PI;
            //Pohrana vrijednosti iz varijabli natrag u TextBox kontrole.
            txtPolumjer.Text = polumjer.ToString();
            txtPovrsina.Text = Math.Round(povrsina, 2).ToString();
            txtOpseg.Text = Math.Round(opseg, 2).ToString();
            //Spremanje vrijednosti polumjera u ListBox kontrolu
            //ako je CheckBox uključen
            if (chkSpremi.Checked == true)
            {
                lstRezultati.Items.Add(polumjer);
            }
        }
        private void btnOcisti_Click(object sender, EventArgs e)
        {
            //Postavlja sadržaj TextBox-ova na zadane vrijednosti
            txtPolumjer.Text = "0,00";
            txtPovrsina.Text = "0,00";
            txtOpseg.Text = "0,00";
            //Briše elemente iz ListBox-a
            lstRezultati.Items.Clear();
        }
        private void lstRezultati_DoubleClick(object sender, EventArgs e)
        {
            //Dohvaćamo vrijednost polumjera iz ListBox-a u varijablu
            float polumjer = 0;
            float.TryParse(lstRezultati.SelectedItem.ToString(), out polumjer);
            //Postavljamo vrijednost polumjera u TextBox
            txtPolumjer.Text = polumjer.ToString();
            //Pozivamo ponovno izvršavanje izračuna
            btnIzracunaj_Click(null, null);
        }
    }
}
