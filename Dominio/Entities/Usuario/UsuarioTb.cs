using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities.Usuario
{
    public class UsuarioTb
    {
        public int Id { get; set; }
        public string tx_Nome { get; set; }
        public string tx_Email { get; set; }
        public string tx_Username { get; set; }
        public int? Id_CriadoPor { get; set; }
        public bool fl_TrocarSenha { get; set; }
        public string tx_Token { get; set; }
        public bool fl_SuperUser { get; set; }
        public DateTime dt_CreateDate { get; set; }
        public DateTime dt_UpdateDate { get; set; }
        public bool fl_IsEnabled { get; set; }
        public string tx_Senha { get; set; }
        public int? Id_DesabilitadoPor { get; set; }
        public string Tx_Caminho_Img_Usuario { get; set; }
        public bool? fl_sessao { get; set; }
        public int? Nr_Module_Default { get; set; }
        public int? nr_PerfilId { get; set; }
        public bool? fl_ChangePassword { get; set; }
        public string Tx_Caminho_Img_Empresa { get; set; }
        public bool? fl_Auditor { get; set; }
        public int? Nr_EmpresaPadrao { get; set; }
        public bool? Fl_AceiteTermos { get; set; }
        public string Tx_TokenAceiteTermos { get; set; }
        public DateTime? Dt_AceiteTermos { get; set; }
        public string Tx_TokenValidate { get; set; }
        public bool? fl_LimiteFatura { get; set; }
    }
}
