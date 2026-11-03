using System;

namespace Ruan_Silva_DR2_TP1.Exercicio4.CalculadoraTarifa;

public class Program {
    public static void Main() {
        const double tetoDiario = 50.00;

        Console.Write("Informe o total de minutos estacionados: ");
        string entradaMinutos = Console.ReadLine();

        if (!int.TryParse(entradaMinutos, out int totalMinutos) || totalMinutos < 0) {
            Console.WriteLine("Entrada inválida. Informe um número inteiro de minutos não negativo.");
            return;
        }

        Console.Write("Informe o valor cobrado por hora: ");
        string entradaValorHora = Console.ReadLine();

        if (!double.TryParse(entradaValorHora, out double valorHora) || valorHora < 0) {
            Console.WriteLine("Entrada inválida. Informe um valor por hora numérico não negativo.");
            return;
        }

        int horasCheias = totalMinutos / 60;
        int minutosRestantes = totalMinutos % 60;

        Console.WriteLine($"{horasCheias}h {minutosRestantes}min");

        int horasCobradas = minutosRestantes > 0 ? horasCheias + 1 : horasCheias;
        double valorCalculado = horasCobradas * valorHora;

        Console.WriteLine($"Horas cobradas: {horasCobradas}");
        Console.WriteLine($"Valor calculado: R$ {valorCalculado:F2}");

        if (valorCalculado > tetoDiario) {
            Console.WriteLine($"O valor calculado é maior que o teto diário de R$ {tetoDiario:F2}.");
        } else if (valorCalculado < tetoDiario) {
            Console.WriteLine($"O valor calculado é menor que o teto diário de R$ {tetoDiario:F2}.");
        } else {
            Console.WriteLine($"O valor calculado é igual ao teto diário de R$ {tetoDiario:F2}.");
        }
    }
}
