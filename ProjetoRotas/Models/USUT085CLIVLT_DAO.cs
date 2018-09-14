using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace ProjetoRotas.Models
{
    public class USUT085CLIVLT_DAO
    {

        public List<EnderecoQuantidade> BuscarEndereco()
        {
            try
            {
                string OracleStringConnection = "DATA SOURCE=ORA11GT; PASSWORD=nwms4651teste;USER ID=NWMS_PRODUCAO";
                string sql = @"SELECT DISTINCT(VLT.USU_CLIVLT) AS CLIENTE, USU.USU_ENDENT AS ENDERECO, USU.USU_BAIENT AS BAIRRO, USU.USU_CIDENT CIDADE, 
                            USU.USU_ESTENT ESTADO, SUM(VLT.USU_CUBMAX) AS CUBAGEM, SUM(VLT.USU_PESBRU) AS PESO_BRUTO, SUM(VLT.USU_VLRBRU) AS VALOR_BRUTO 
                            FROM SAPIENS.USU_T120PEDVLT VLT , SAPIENS.USU_T085CLIVLT USU
                            WHERE  VLT.USU_DATVLT >= TO_DATE('2018/08/29', 'YYYY/MM/DD') AND VLT.USU_CLIVLT = USU.USU_CLIVLT AND USU.USU_BAIENT = 'CENTRO' 
                            AND VLT.USU_ROTVLT = 6103 GROUP BY VLT.USU_CLIVLT, USU.USU_ENDENT, USU.USU_BAIENT, USU.USU_CIDENT, USU.USU_ESTENT";

                OracleConnection conn = new OracleConnection(OracleStringConnection);
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                OracleDataReader dr = cmd.ExecuteReader();

                List<EnderecoQuantidade> ListaItens = new List<EnderecoQuantidade>();
                EnderecoQuantidade itens = new EnderecoQuantidade();
                                
                while (dr.Read())
                {
                    itens = new EnderecoQuantidade();
                    itens.CLIENTE = dr["CLIENTE"].ToString();
                    itens.ENDERECO = dr["ENDERECO"].ToString();
                    itens.BAIRRO = dr["BAIRRO"].ToString();
                    itens.CIDADE = dr["CIDADE"].ToString();
                    itens.ESTADO = dr["ESTADO"].ToString();
                    itens.CUBAGEM = Convert.ToDecimal(dr["CUBAGEM"]);
                    itens.PESO_BRUTO = Convert.ToDecimal(dr["PESO_BRUTO"]);
                    itens.VALOR_BRUTO = Convert.ToDecimal(dr["VALOR_BRUTO"]);
                    itens.ENDERECOCOMPLETO = dr["ENDERECO"].ToString().Trim() + "," + dr["BAIRRO"].ToString().Trim() + "," + dr["CIDADE"].ToString().Trim() + "," + dr["ESTADO"].ToString().Trim();
                    ListaItens.Add(itens);
                }
                return ListaItens;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<USUT085CLIVLT> ListarTodos()
        {
            try
            {
                string OracleStringConnection = "DATA SOURCE=ORA11GT; PASSWORD=nwms4651teste;USER ID=NWMS_PRODUCAO";

                string sql = @"SELECT USU.USU_CLIVLT, USU.USU_NOMCLI, USU.USU_CIDENT, USU.USU_ENDENT, USU.USU_BAIENT, USU.USU_LATENT, USU.USU_LONENT, USU.USU_ESTENT, USU.USU_STSCLI, USU.USU_MSGERR, USU.USU_CODCLI, USU.USU_SEQENT, USU.USU_CEPENT, USU.USU_DATGER, USU.USU_HORGER
                                FROM SAPIENS.USU_T085CLIVLT USU WHERE USU.USU_STSCLI = 0 and usu.usu_codcli = 17887";

                OracleConnection conn = new OracleConnection(OracleStringConnection);
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                OracleDataReader dr = cmd.ExecuteReader();

                List<USUT085CLIVLT> itensLista = new List<USUT085CLIVLT>();
                USUT085CLIVLT itens = new USUT085CLIVLT();

                while (dr.Read())
                {
                    itens = new USUT085CLIVLT();
                    {
                        itens.USU_CLIVLT = dr["USU_CLIVLT"].ToString();
                        itens.USU_NOMCLI = dr["USU_NOMCLI"].ToString();
                        itens.USU_CIDENT = dr["USU_CIDENT"].ToString();
                        itens.USU_ENDENT = dr["USU_ENDENT"].ToString();
                        itens.USU_BAIENT = dr["USU_BAIENT"].ToString();
                        itens.USU_LATENT = Convert.ToInt32(dr["USU_LATENT"]);
                        itens.USU_LONENT = Convert.ToInt32(dr["USU_LONENT"]);
                        itens.USU_ESTENT = dr["USU_ESTENT"].ToString();
                        itens.USU_STSCLI = Convert.ToInt32(dr["USU_STSCLI"]);
                        itens.USU_MSGERR = dr["USU_MSGERR"].ToString();
                        itens.USU_CODCLI = Convert.ToInt32(dr["USU_CODCLI"]);
                        itens.USU_SEQENT = Convert.ToInt32(dr["USU_SEQENT"]);
                        itens.USU_CEPENT = dr["USU_CEPENT"].ToString();
                        itensLista.Add(itens);
                    }
                }
                return itensLista;
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}