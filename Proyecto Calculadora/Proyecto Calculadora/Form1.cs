using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Proyecto_Calculadora
{
    public partial class Form1 : Form
    {
        // 🔹 Conexión a SQL Server
        string CONN = @"Server=.\sqlexpress;Database=CalculadoraDB;Trusted_Connection=True;";

        // 🔹 Variables principales
        double num1 = 0;
        double num2 = 0;
        string operacion = "";
        bool nuevaEntrada = true;

        public Form1()
        {
            InitializeComponent();
            CrearBotones();
        }

        // ------------------ CREACIÓN DE BOTONES ------------------
        private void CrearBotones()
        {
            string[,] botones = new string[,]
            {
                { "CE", "C", "√", "x²" },
                { "7", "8", "9", "/" },
                { "4", "5", "6", "*" },
                { "1", "2", "3", "-" },
                { "+/-", "0", ".", "+" },
                { "=", "Mostrar cálculos", "Vaciar tabla", "" }
            };

            for (int r = 0; r < botones.GetLength(0); r++)
            {
                for (int c = 0; c < botones.GetLength(1); c++)
                {
                    string texto = botones[r, c];
                    if (texto == "") continue;

                    Button btn = new Button
                    {
                        Text = texto,
                        Dock = DockStyle.Fill,
                        Font = new System.Drawing.Font("Segoe UI", 12),
                        ForeColor = System.Drawing.Color.Black,
                        BackColor = System.Drawing.SystemColors.Control,
                        FlatStyle = FlatStyle.Standard,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    };
                    btn.Click += Btn_Click;
                    panelBotones.Controls.Add(btn, c, r);
                }
            }
        }

        // ------------------ EVENTO PRINCIPAL ------------------
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string t = btn.Text;

            // Números
            if (char.IsDigit(t, 0))
            {
                if (nuevaEntrada)
                {
                    txtDisplay.Text = t;
                    nuevaEntrada = false;
                }
                else
                {
                    txtDisplay.Text += t;
                }
                return;
            }

            // Operaciones
            switch (t)
            {
                case ".":
                    if (!txtDisplay.Text.Contains(".")) txtDisplay.Text += ".";
                    break;

                case "+":
                case "-":
                case "*":
                case "/":
                    num1 = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
                    operacion = t;
                    nuevaEntrada = true;
                    break;

                case "=":
                    num2 = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
                    Calcular();
                    break;

                case "C":
                    txtDisplay.Text = "0";
                    num1 = num2 = 0;
                    operacion = "";
                    nuevaEntrada = true;
                    break;

                case "CE":
                    txtDisplay.Text = "0";
                    nuevaEntrada = true;
                    break;

                case "+/-":
                    if (txtDisplay.Text.StartsWith("-"))
                        txtDisplay.Text = txtDisplay.Text.Substring(1);
                    else if (txtDisplay.Text != "0")
                        txtDisplay.Text = "-" + txtDisplay.Text;
                    break;

                case "x²":
                    double cuadrado = Math.Pow(double.Parse(txtDisplay.Text), 2);
                    GuardarOperacion($"{txtDisplay.Text}²", cuadrado);
                    txtDisplay.Text = cuadrado.ToString();
                    break;

                case "√":
                    double valor = double.Parse(txtDisplay.Text);
                    if (valor < 0) { MessageBox.Show("No se puede raíz de negativo"); return; }
                    double raiz = Math.Sqrt(valor);
                    GuardarOperacion($"√({valor})", raiz);
                    txtDisplay.Text = raiz.ToString();
                    break;

                case "Mostrar cálculos":
                    dgvOperaciones.Visible = !dgvOperaciones.Visible;
                    if (dgvOperaciones.Visible)
                        dgvOperaciones.DataSource = ObtenerOperaciones();
                    break;

                case "Vaciar tabla":
                    VaciarTabla();
                    break;
            }
        }

        // ------------------ LÓGICA DE CÁLCULO ------------------
        private void Calcular()
        {
            double resultado = 0;

            switch (operacion)
            {
                case "+": resultado = num1 + num2; break;
                case "-": resultado = num1 - num2; break;
                case "*": resultado = num1 * num2; break;
                case "/":
                    if (num2 == 0) { MessageBox.Show("División por cero"); return; }
                    resultado = num1 / num2; break;
            }

            string expresion = $"{num1} {operacion} {num2}";
            txtDisplay.Text = resultado.ToString(CultureInfo.InvariantCulture);
            GuardarOperacion(expresion, resultado);
            nuevaEntrada = true;
        }

        // ------------------ BASE DE DATOS ------------------
        private void GuardarOperacion(string op, double res)
        {
            try
            {
                 var conn = new SqlConnection(CONN);
                conn.Open();
                string sql = "INSERT INTO Operaciones (Operacion, Resultado) VALUES (@o,@r)";
                 var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@o", op);
                cmd.Parameters.AddWithValue("@r", res.ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private DataTable ObtenerOperaciones()
        {
            DataTable dt = new DataTable();
            try
            {
                 var conn = new SqlConnection(CONN);
                conn.Open();
                 var da = new SqlDataAdapter("SELECT * FROM Operaciones ORDER BY FechaHora DESC", conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer datos: " + ex.Message);
            }
            return dt;
        }

        private void VaciarTabla()
        {
            if (MessageBox.Show("¿Borrar todo?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                 var conn = new SqlConnection(CONN);
                conn.Open();
                 var cmd = new SqlCommand("DELETE FROM Operaciones", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registros eliminados.");
            }
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
