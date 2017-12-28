﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benaiah
{
    public partial class Inicio : Form
    {
        List<Funcionarios> listaFuncionarios;
        private string nome;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            lblIdentificada.Visible = false;
            lblNomeFuncionaria.Visible = false;
            BtnIniciar.Visible = false;

            listaFuncionarios = new List<Funcionarios>();
            listaFuncionarios.Add(new Funcionarios("ALDENIRA PEREIRA MORAES", "Cozinha"));
            listaFuncionarios.Add(new Funcionarios("ANA LUCIA FERREIRA DOS SANTOS", "Cozinha"));
            listaFuncionarios.Add(new Funcionarios("BEATRIZ ADALBERTO DOS SANTOS", "Cozinha"));
            listaFuncionarios.Add(new Funcionarios("MARIA OZENI FERREIRA LEITE", "Cozinha"));
            listaFuncionarios.Add(new Funcionarios("VALERIA CRISTINA DE AGUIAR", "Cozinha"));
            listaFuncionarios.Add(new Funcionarios("CAROLINE MARCILENE BARREIRA DE PIERI", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("DAIANY RENATA THOMAZINI", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("DANIELY CAMARGO NUNES", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("DEBORAH DE ASSIS SILVA", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("JULIANA MARIA DA SILVA DOMINGUES", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("LUCIANA APARECIDA NOGUEIRA DE CAMPOS", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("MARILEIDE LEANDRA CURVO", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("MARINA PEREIRA DA SILVA", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("MAYARA RIBEIRO DA CRUZ", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("MIRELLE SAMIRA VAZ", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("ODETE MEDEIROS DE SOUZA", "Enfermagem"));
            listaFuncionarios.Add(new Funcionarios("FRANCISCA MARIA DE JESUS SANTOS", "Serviços gerais"));
            listaFuncionarios.Add(new Funcionarios("IVETE FERREIRA DOS SANTOS", "Serviços gerais"));
            listaFuncionarios.Add(new Funcionarios("MARIA GORETTI DE BESSA", "Serviços gerais"));
            listaFuncionarios.Add(new Funcionarios("MARTA GRIGOLETE CORREA", "Serviços gerais"));
            listaFuncionarios.Add(new Funcionarios("RONILDA CIRINO TOMAZ DE ARAUJO", "Serviços gerais"));
            listaFuncionarios.Add(new Funcionarios("TANIA APARECIDA LUCIO", "Serviços gerais"));
            listaFuncionarios.Add(new Funcionarios("VANUSA MARIA DA SILVA", "Serviços gerais"));

            //listaFuncionarios.Add(new Funcionarios("JULIANA PINARELLI DE CURTIS", "Técnica"));
            //listaFuncionarios.Add(new Funcionarios("MARCELA CRISTINA BARBERA", "Técnica"));
            //listaFuncionarios.Add(new Funcionarios("MARIANA SINICIATO HENRIQUES", "Técnica"));
            //listaFuncionarios.Add(new Funcionarios("ROSANA DE CAMARGO VALOTO", "Técnica"));
            //listaFuncionarios.Add(new Funcionarios("TAMIRES DE ANGELO CANDIDO", "Técnica"));
            //listaFuncionarios.Add(new Funcionarios("VIVIANE LEMBO", "Técnica"));
            //listaFuncionarios.Add(new Funcionarios("FERNANDA DE OLIVEIRA VIEIRA", "Outros"));
            //listaFuncionarios.Add(new Funcionarios("VANILDE MARTINELI DE OLIVEIRA CAMARGO", "Outros"));
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text.Equals("0")) { SetupAoAcertarSenha(listaFuncionarios[0].Funcionario); nome = listaFuncionarios[0].Funcionario; }
            else if (txtSenha.Text.Equals("1")) { SetupAoAcertarSenha(listaFuncionarios[1].Funcionario); nome = listaFuncionarios[1].Funcionario; }
            else if (txtSenha.Text.Equals("2")) { SetupAoAcertarSenha(listaFuncionarios[2].Funcionario); nome = listaFuncionarios[2].Funcionario; }
            else if (txtSenha.Text.Equals("3")) { SetupAoAcertarSenha(listaFuncionarios[3].Funcionario); nome = listaFuncionarios[3].Funcionario; }
            else if (txtSenha.Text.Equals("4")) { SetupAoAcertarSenha(listaFuncionarios[4].Funcionario); nome = listaFuncionarios[4].Funcionario; }
            else if (txtSenha.Text.Equals("5")) { SetupAoAcertarSenha(listaFuncionarios[5].Funcionario); nome = listaFuncionarios[5].Funcionario; }
            else if (txtSenha.Text.Equals("6")) { SetupAoAcertarSenha(listaFuncionarios[6].Funcionario); nome = listaFuncionarios[6].Funcionario; }
            else if (txtSenha.Text.Equals("7")) { SetupAoAcertarSenha(listaFuncionarios[7].Funcionario); nome = listaFuncionarios[7].Funcionario; }
            else if (txtSenha.Text.Equals("8")) { SetupAoAcertarSenha(listaFuncionarios[8].Funcionario); nome = listaFuncionarios[8].Funcionario; }
            else if (txtSenha.Text.Equals("9")) { SetupAoAcertarSenha(listaFuncionarios[9].Funcionario); nome = listaFuncionarios[9].Funcionario; }
            else if (txtSenha.Text.Equals("10")) { SetupAoAcertarSenha(listaFuncionarios[10].Funcionario); nome = listaFuncionarios[10].Funcionario; }
            else if (txtSenha.Text.Equals("11")) { SetupAoAcertarSenha(listaFuncionarios[11].Funcionario); nome = listaFuncionarios[11].Funcionario; }
            else if (txtSenha.Text.Equals("12")) { SetupAoAcertarSenha(listaFuncionarios[12].Funcionario); nome = listaFuncionarios[12].Funcionario; }
            else if (txtSenha.Text.Equals("13")) { SetupAoAcertarSenha(listaFuncionarios[13].Funcionario); nome = listaFuncionarios[13].Funcionario; }
            else if (txtSenha.Text.Equals("14")) { SetupAoAcertarSenha(listaFuncionarios[14].Funcionario); nome = listaFuncionarios[14].Funcionario; }
            else if (txtSenha.Text.Equals("15")) { SetupAoAcertarSenha(listaFuncionarios[15].Funcionario); nome = listaFuncionarios[15].Funcionario; }
            else if (txtSenha.Text.Equals("16")) { SetupAoAcertarSenha(listaFuncionarios[16].Funcionario); nome = listaFuncionarios[16].Funcionario; }
            else if (txtSenha.Text.Equals("17")) { SetupAoAcertarSenha(listaFuncionarios[17].Funcionario); nome = listaFuncionarios[17].Funcionario; }
            else if (txtSenha.Text.Equals("18")) { SetupAoAcertarSenha(listaFuncionarios[18].Funcionario); nome = listaFuncionarios[18].Funcionario; }
            else if (txtSenha.Text.Equals("19")) { SetupAoAcertarSenha(listaFuncionarios[19].Funcionario); nome = listaFuncionarios[19].Funcionario; }
            else if (txtSenha.Text.Equals("20")) { SetupAoAcertarSenha(listaFuncionarios[20].Funcionario); nome = listaFuncionarios[20].Funcionario; }
            else if (txtSenha.Text.Equals("21")) { SetupAoAcertarSenha(listaFuncionarios[21].Funcionario); nome = listaFuncionarios[21].Funcionario; }
            else if (txtSenha.Text.Equals("22")) { SetupAoAcertarSenha(listaFuncionarios[22].Funcionario); nome = listaFuncionarios[22].Funcionario; }
        }

        private void SetupAoAcertarSenha(string nome)
        {
            lblIdentificada.Visible = true;
            lblNomeFuncionaria.Visible = true;
            BtnIniciar.Visible = true;
            lblNomeFuncionaria.Text = nome;
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            Hide();
            foreach (var item in listaFuncionarios)
            {
                if (!item.Funcionario.Equals(nome))
                {
                    var categoria = listaFuncionarios.Where(p => p.Funcionario.Equals(nome)).Select(x => x.Setor).ToList();
                    if (categoria[0].ToString().Equals(item.Setor))
                    {
                        SetorIgual sIgual = new SetorIgual(item.Funcionario, item.Setor);
                        sIgual.ShowDialog();
                    }
                    else
                    {
                        SetorDiferente sDiferente = new SetorDiferente(item.Funcionario, item.Setor);
                        sDiferente.ShowDialog();
                    }
                }
            }
            Close();
        }
    }
}