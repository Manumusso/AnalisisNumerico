﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalisisNumerico.BackEnd.Logica;

namespace AnalisisNumerico.FrontEnd.MetodosRaicesMenu
{
    public partial class MenuPrincipalRaices : Form
    {
        private readonly IMetodosRaices metodosRaices;

        public MenuPrincipalRaices()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Calcular_Click(object sender, EventArgs e)
        {
            var parametros = new ParametrosRaices();
            // Se comprueba que no exista texbox sin datos
            if (String.IsNullOrWhiteSpace(textBox_Funcion.Text) ||
                String.IsNullOrWhiteSpace(textBox_Tolerancia.Text) ||
               String.IsNullOrWhiteSpace(textBox_Iteraciones.Text) ||
               String.IsNullOrWhiteSpace(textBox_ValorDerecho.Text) ||
               String.IsNullOrWhiteSpace(textBox_ValorIzquierdo.Text))
            {
                MessageBox.Show("Faltan ingresar datos", "Notificación", MessageBoxButtons.OK);
            }
            else
            {
                parametros.Funcion = textBox_Funcion.Text;
                parametros.Iteraciones = int.Parse(textBox_Iteraciones.Text);
                parametros.Tolerancia = double.Parse(textBox_Tolerancia.Text);
                parametros.ValorDerecho = double.Parse(textBox_ValorDerecho.Text);
                parametros.ValorIzquierdo = double.Parse(textBox_ValorIzquierdo.Text);
                parametros.Finalizo = true;

                var resultado = metodosRaices.MetodoBiseccionReglaFalsa(parametros);

                if (resultado.Observacion == "")
                {
                    textBox_Error.Text = resultado.Error.ToString("N8");
                    textBox_Iteraciones.Text = resultado.Iteraciones.ToString();
                    textBox_Raiz.Text = resultado.Raiz.ToString("N8");
                }
                else
                {
                    MessageBox.Show("Los extremos ingresados no son válidos", "Notificación", MessageBoxButtons.OK);
                }
            }
        }

        private void MenuPrincipalRaices_Load(object sender, EventArgs e)
        {

        }
    }
}