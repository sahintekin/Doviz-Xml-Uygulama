using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizProjeXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);


            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDolarAlıs.Text= dolaralis;

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSatıs.Text = dolarsatis;


            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroAlıs.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSatıs.Text = eurosatis;
        }

        private void btnDolarAl_Click(object sender, EventArgs e)
        {
            textKur.Text = lblDolarAlıs.Text;
        }

        private void btnDolarSat_Click(object sender, EventArgs e)
        {
            textKur.Text = lblDolarSatıs.Text;
        }

        private void btnEuroAl_Click(object sender, EventArgs e)
        {
            textKur.Text = lblEuroAlıs.Text;
        }

        private void btnEuroSat_Click(object sender, EventArgs e)
        {
            textKur.Text = lblEuroSatıs.Text;

        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(textKur.Text);
            miktar = Convert.ToDouble(textMiktar.Text);
            tutar = kur * miktar;
            textTutar.Text=tutar.ToString();    
        }

        private void textKur_TextChanged(object sender, EventArgs e)
        {
            textKur.Text = textKur.Text.Replace(".", ",");
        }

        private void btnSatisYap2_Click(object sender, EventArgs e)
        {
            double kur =Convert.ToDouble(textKur.Text);
            int miktar=Convert.ToInt32(textMiktar.Text);
            int tutar =Convert.ToInt32( miktar/ kur);
            textTutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            textKalan.Text = kalan.ToString();

        }
    }
}
