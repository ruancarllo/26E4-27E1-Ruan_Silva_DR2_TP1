using System;

namespace Ruan_Silva_DR2_TP1.Exercicio1.AmbienteEstacionamento;
public class Program {
    public static void Main(string[] args){
        Console.WriteLine("Nome do sistema atual: " + Environment.OSVersion);
        Console.WriteLine("Versão .NET: " + Environment.Version);
        Console.WriteLine("Diretório de trabalho atual: " + Environment.CurrentDirectory);
    }
}
