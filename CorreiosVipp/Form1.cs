using CorreiosVipp.PostagemVipp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorreiosVipp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /**************************************
             * Informações do Manual para teste
             *************************************/
            PerfilVipp perfil = new PerfilVipp();
            perfil.IdPerfil = "604";
            perfil.Usuario = "webservice";
            perfil.Token = "testewebservice";

            ContratoEct contrato = new ContratoEct();
            contrato.CodigoAdministrativo = "0013291092";
            contrato.NrCartao = "0067335344";
            contrato.NrContrato = "9912329784";
            /**************************************
             * 
             *************************************/
            Destinatario destinatario = new Destinatario();
            destinatario.CnpjCpf = "61936522000194";
            destinatario.Nome = "Celmar";
            destinatario.Endereco = "AV. COND. ELISABETH DE ROBIANO";
            destinatario.Numero = "930";
            destinatario.Cidade = "SÃO PAULO";
            destinatario.Cep = "03074000";
            destinatario.Telefone = "1125006298";
            destinatario.Email = "e.pereira@celmar.com.br";
            destinatario.UF = "SP";
            Servico servico = new Servico();
            servico.ServicoECT = "04162";

            NotaFiscal nf = new NotaFiscal();
            nf.NrNotaFiscal = "000001";
            
            VolumeObjeto volume = new VolumeObjeto();
            
            Postagem p = new Postagem();
            p.PerfilVipp = perfil;
            p.ContratoEct = contrato;
            p.Destinatario = destinatario;
            p.Servico = servico;
            p.NotasFiscais = new NotaFiscal[] { nf };
            p.Volumes = new VolumeObjeto[] { volume };

            PostagemVippSoapClient ws = new PostagemVippSoapClient();

            var retorno = ws.PostarObjeto(p);
            Console.WriteLine(JsonConvert.SerializeObject(retorno, Formatting.Indented));

             
            
        }
    }
}
