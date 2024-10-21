using System;
using System.Data.OleDb;
using System.IO;


//Desenvolvido por:

//Danilo Franco de Oliveira




public class Banco
{
    private string connectionString;

    
    public static string caminho = AppDomain.CurrentDomain.BaseDirectory;

    
    public static string nomeBanco = "auebd.mdb";

    
    public static string caminhoBanco = Path.Combine(caminho, nomeBanco);

    public Banco()
    {
        
        connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={caminhoBanco};";
    }

    
    public string ConnectionString
    {
        get { return connectionString; }
    }

    public OleDbConnection ObterConexao()
    {
        return new OleDbConnection(connectionString);
    }
}

