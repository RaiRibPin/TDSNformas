using System;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TDSNformas
{
    public partial class APFormas : Form
    {
        public APFormas()
        {
            InitializeComponent();
        }

        private void APFormas_Load(object sender, EventArgs e)
        {
            ExibirTriangulo(false);
            ExibirAltura(false);
            ExibirBase(false);
            ExibirLado(false);
            ExibirRaio(false);
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Circunferência":
                    {
                        ExibirRaio(true);
                        ExibirLado(false);
                        ExibirAltura(false);
                        ExibirBase(false);
                        ExibirTriangulo(false);
                        ExibirHipotenusa(false);
                        Limpar();
                        break;
                    }
                case "Quadrado":
                    {
                        ExibirRaio(false);
                        ExibirLado(true);
                        ExibirAltura(false);
                        ExibirBase(false);
                        ExibirTriangulo(false);
                        ExibirHipotenusa(false);
                        Limpar();
                        break;
                    }
                case "Retângulo":
                    {
                        ExibirRaio(false);
                        ExibirLado(false);
                        ExibirAltura(true);
                        ExibirBase(true);
                        ExibirTriangulo(false);
                        ExibirHipotenusa(false);
                        Limpar();
                        break;
                    }
                case "Triângulo":
                    {
                        ExibirRaio(false);
                        ExibirLado(false);
                        ExibirAltura(true);
                        ExibirBase(true);
                        ExibirTriangulo(true);
                        ExibirHipotenusa(true);
                        Limpar();
                        break;
                    }
            }
        }

        private void Limpar()
        {
            txtArea.Text = "";
            txtPerimetro.Text = "";
            txtHipotenusa.Text = "";
        }

        private void ExibirHipotenusa(bool visivel)
        {
            txtHipotenusa.Visible = visivel;
            lblHipotenusa.Visible = visivel;
        }

        private void ExibirTriangulo(bool visivel)
        {
            cmbTriangulo.Visible = visivel;
            lblTriangulo.Visible = visivel;
        }

        private void ExibirBase(bool visivel)
        {
            lblBase.Visible = txtBase.Visible = visivel;
        }

        private void ExibirAltura(bool visivel)
        {
            lblAltura.Visible = txtAltura.Visible = visivel;
        }

        private void ExibirLado(bool visivel)
        {
            lblLado.Visible = txtLado.Visible = visivel;
        }

        private void ExibirRaio(bool visivel)
        {
            lblRaio.Visible = txtRaio.Visible = visivel;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (txtBase.Text != "" && txtAltura.Text != "" || txtLado.Text != "" || txtRaio.Text != "" || cmbTriangulo.Text == "Equilátero" && txtBase.Text != "")
            {
                if (Regex.IsMatch(txtLado.Text, @"^\d+(,\d+)?$") || Regex.IsMatch(txtAltura.Text, @"^\d+(,\d+)?$") && Regex.IsMatch(txtBase.Text, @"^\d+(,\d+)?$") || cmbTriangulo.Text == "Equilátero" && Regex.IsMatch(txtBase.Text, @"^\d+(,\d+)?$") || Regex.IsMatch(txtRaio.Text, @"^\d+(,\d+)?$"))
                {
                    switch (cmbForma.Text)
                    {
                        case "Quadrado":
                            {
                                FormaGeometrica objeto;
                                objeto = new Quadrado() { Lado = Convert.ToDouble(txtLado.Text, new CultureInfo("pt-BR")) };
                                cmbObjetos.Items.Add(objeto);
                                txtLado.Clear();
                                break;
                            }
                        case "Retângulo":
                            {
                                FormaGeometrica objeto;
                                objeto = new Retângulo()
                                {
                                    Altura = Convert.ToDouble(txtAltura.Text, new CultureInfo("pt-BR")),
                                    Base = Convert.ToDouble(txtBase.Text, new CultureInfo("pt-BR"))
                                };
                                cmbObjetos.Items.Add(objeto);
                                txtAltura.Clear();
                                txtBase.Clear();
                                break;
                            }
                        case "Circunferência":
                            {
                                FormaGeometrica objeto;
                                objeto = new Circunferência()
                                {
                                    Raio = Convert.ToDouble(txtRaio.Text, new CultureInfo("pt-BR")),
                                };
                                cmbObjetos.Items.Add(objeto);
                                txtRaio.Clear();
                                break;
                            }
                        case "Triângulo":
                            {
                                if (cmbTriangulo.Text == "Reto")
                                {
                                    FormaGeometrica objeto;
                                    objeto = new TriânguloReto()
                                    {
                                        Base = Convert.ToDouble(txtBase.Text, new CultureInfo("pt-BR")),
                                        Altura = Convert.ToDouble(txtAltura.Text, new CultureInfo("pt-BR"))
                                    };
                                    cmbObjetos.Items.Add(objeto);
                                    txtBase.Clear();
                                    txtAltura.Clear();
                                }
                                else if (cmbTriangulo.Text == "Equilátero")
                                {
                                    FormaGeometrica objeto;
                                    objeto = new TriânguloEquilátero() { Base = Convert.ToDouble(txtBase.Text, new CultureInfo("pt-BR")) };
                                    cmbObjetos.Items.Add(objeto);
                                    txtBase.Clear();
                                }
                                else if (cmbTriangulo.Text == "Isósceles")
                                {
                                    FormaGeometrica objeto;
                                    objeto = new TriânguloIsósceles()
                                    {
                                        Base = Convert.ToDouble(txtBase.Text, new CultureInfo("pt-BR")),
                                        Lado = Convert.ToDouble(txtLado.Text, new CultureInfo("pt-BR"))
                                    };
                                    cmbObjetos.Items.Add(objeto);
                                    txtBase.Clear();
                                    txtLado.Clear();
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                else { MessageBox.Show("Digite apenas números!"); }
            }
            else { MessageBox.Show("Insira um valor!"); }
        }

            private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormaGeometrica objeto = cmbObjetos.SelectedItem as FormaGeometrica;
               txtArea.Text= objeto.CalcularArea().ToString();
               txtPerimetro.Text = objeto.CalcularPerímetro().ToString();

            if (cmbObjetos.Text.Contains("Reto") || cmbObjetos.Text.Contains("Isósceles") || cmbObjetos.Text.Contains("Equilátero")) {
            Triângulo objecto = cmbObjetos.SelectedItem as Triângulo;
                txtHipotenusa.Text = objecto.CalcularHipotenusa().ToString();
                AlturaEquilátero.Text = objecto.Altura.ToString();
            }
        }

        private void cmbTriangulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTriangulo.Text)
            {
                case "Reto":
                    {
                        AlturaHabilitada();
                        ExibirRaio(false);
                        ExibirLado(false);
                        ExibirAltura(true);
                        ExibirBase(true);
                        ExibirHipotenusa(true);
                        Limpar();
                        break;
                    }
                case "Equilátero":
                    {
                        txtAltura.Visible = false;
                        txtAltura.Enabled = false;
                        AlturaEquilátero.Visible = true;
                        ExibirLado(false);
                        ExibirRaio(false);
                        ExibirBase(true);
                        ExibirHipotenusa(false);
                        Limpar();
                        break;
                    }
                case "Isósceles":
                    {
                        AlturaHabilitada();
                        ExibirAltura(false);
                        ExibirRaio(false);
                        ExibirLado(true);
                        ExibirBase(true);
                        ExibirHipotenusa(true);
                        Limpar();
                        break;
                    }
            }
        }

        private void AlturaHabilitada()
        {
            AlturaEquilátero.Visible = false;
            txtAltura.Enabled = true;
        }
    }
}