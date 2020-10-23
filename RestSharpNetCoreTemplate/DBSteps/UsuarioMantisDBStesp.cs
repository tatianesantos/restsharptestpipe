using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpNetCoreTemplate.DBSteps
{
    public class UsuariosManitsDBSteps
    {
        public static string RetornaSenhaDoUsuario(string username)
        {
            string query = UsuariosQueries.RetornaSenhaUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosMyQuery(query)[1];
        }

        public static List<string> RetornaDados(string username)
        {
            string query = UsuariosQueries.RetornaSenhaUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosMyQuery(query);
        }
    }
}
