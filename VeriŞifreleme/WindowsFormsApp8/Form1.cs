using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-493DFJA\SQLEXPRESS;Initial Catalog=VERISIFRELEME;Integrated Security=True");
        void listele1()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TblVeriSifreli", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlDataAdapter da2 = new SqlDataAdapter("select * from TblVeriSifresiz", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;


        }
      
        
        private void Form1_Load(object sender, EventArgs e)
        {
            listele1();
            groupBox2.Visible = false;
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String metin = txtad.Text;
            byte[] veridizisi = ASCIIEncoding.ASCII.GetBytes(metin);
            string adsifre = Convert.ToBase64String(veridizisi);
          

            String metin1 = txtsoyad.Text;
            byte[] veridizisi1 = ASCIIEncoding.ASCII.GetBytes(metin1);
            string soyadsıfre = Convert.ToBase64String(veridizisi1);
            

            String metin2 = txtmail.Text;
            byte[] veridizisi2 = ASCIIEncoding.ASCII.GetBytes(metin2);
            string mailsifre = Convert.ToBase64String(veridizisi2);
            

            String metin3 = txtsifre.Text;
            byte[] veridizisi3 = ASCIIEncoding.ASCII.GetBytes(metin3);
            string sifresifre = Convert.ToBase64String(veridizisi3);
           

            String metin4 = txthesapno.Text;
            byte[] veridizisi4 = ASCIIEncoding.ASCII.GetBytes(metin4);
            string hesapnosifre = Convert.ToBase64String(veridizisi4);

            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into TblVeriSifreli (AD,SOYAD,MAIL,SIFRE,HESAPNO)" +
                " values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            kmt.Parameters.AddWithValue("@p1", adsifre);
            kmt.Parameters.AddWithValue("@p2", soyadsıfre);
            kmt.Parameters.AddWithValue("@p3", mailsifre);
            kmt.Parameters.AddWithValue("@p4", sifresifre);
            kmt.Parameters.AddWithValue("@p5", hesapnosifre);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            
           baglanti.Open();






            SqlCommand kmt1 = new SqlCommand("insert into TblVeriSifresiz (AD,SOYAD,MAIL,SIFRE,HESAPNO)" +
                " values (@t1,@t2,@t3,@t4,@t5)", baglanti);
            kmt1.Parameters.AddWithValue("@t1", txtad.Text);
            kmt1.Parameters.AddWithValue("@t2", txtsoyad.Text);
            kmt1.Parameters.AddWithValue("@t3", txtmail.Text);
            kmt1.Parameters.AddWithValue("@t4", txtsifre.Text);
            kmt1.Parameters.AddWithValue("@t5", txthesapno.Text);
            kmt1.ExecuteNonQuery();
            baglanti.Close();
            listele1();












        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "user" && textBox2.Text=="1234" )
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;

                SqlDataAdapter da2 = new SqlDataAdapter("select * from TblVeriSifresiz", baglanti);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;

            }
            else
            {
                MessageBox.Show("Yanlış şifre veya kullanıcı adı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

           







        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
