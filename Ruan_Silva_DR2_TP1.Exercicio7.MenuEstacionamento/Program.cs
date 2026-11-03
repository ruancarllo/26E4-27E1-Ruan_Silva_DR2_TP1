using System;

namespace Ruan_Silva_DR2_TP1.Exercicio7.MenuEstacionamento;

public class Program {
    public static void Main() {
        bool executando = true;

        do {
            ExibirMenu();
            string entradaOpcao = Console.ReadLine();

            if (!int.TryParse(entradaOpcao, out int opcao)) {
                Console.WriteLine("Opção inválida. Digite um número inteiro entre 1 e 4.");
                continue;
            }

            switch (opcao) {
                case 1:
                    ExecutarCalculoTarifa();
                    break;
                case 2:
                    ExecutarConversaoDuracao();
                    break;
                case 3:
                    ExecutarClassificacaoPermanencia();
                    break;
                case 4:
                    executando = false;
                    Console.WriteLine("Encerrando o menu.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Escolha entre 1 e 4.");
                    break;
            }
        } while (executando);
    }

    public static void ExibirMenu() {
        Console.WriteLine();
        Console.WriteLine("Menu do estacionamento:");
        Console.WriteLine("1 - Calcular tarifa");
        Console.WriteLine("2 - Converter duração em horas e minutos");
        Console.WriteLine("3 - Classificar permanência");
        Console.WriteLine("4 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    public static void ExecutarCalculoTarifa() {
        const double tetoDiario = 50.00;

        int? minutos = LerMinutosEstacionado();
        if (minutos is null) {
            return;
        }

        double? valorHora = LerValorHora();
        if (valorHora is null) {
            return;
        }

        Console.WriteLine(ConverterDuracaoHorasMinutos(minutos.Value));
        double valorCalculado = CalcularTarifa(minutos.Value, valorHora.Value);
        Console.WriteLine($"Valor calculado: R$ {valorCalculado:F2}");

        if (valorCalculado > tetoDiario) {
            Console.WriteLine($"O valor calculado é maior que o teto diário de R$ {tetoDiario:F2}.");
        } else if (valorCalculado < tetoDiario) {
            Console.WriteLine($"O valor calculado é menor que o teto diário de R$ {tetoDiario:F2}.");
        } else {
            Console.WriteLine($"O valor calculado é igual ao teto diário de R$ {tetoDiario:F2}.");
        }
    }

    public static void ExecutarConversaoDuracao() {
        int? minutos = LerMinutosEstacionado();
        if (minutos is null) {
            return;
        }

        Console.WriteLine(ConverterDuracaoHorasMinutos(minutos.Value));
    }

    public static void ExecutarClassificacaoPermanencia() {
        int? minutos = LerMinutosEstacionado();
        if (minutos is null) {
            return;
        }

        Console.WriteLine($"Permanência de {minutos.Value} min classificada como: {ClassificarPermanencia(minutos.Value)}");
    }

    public static int? LerMinutosEstacionado() {
        Console.Write("Informe o total de minutos estacionado: ");
        string entradaMinutos = Console.ReadLine();

        if (!int.TryParse(entradaMinutos, out int minutos) || minutos < 0) {
            Console.WriteLine("Entrada inválida. Informe um número inteiro de minutos não negativo.");
            return null;
        }

        return minutos;
    }

    public static double? LerValorHora() {
        Console.Write("Informe o valor cobrado por hora: ");
        string entradaValorHora = Console.ReadLine();

        if (!double.TryParse(entradaValorHora, out double valorHora) || valorHora < 0) {
            Console.WriteLine("Entrada inválida. Informe um valor por hora numérico não negativo.");
            return null;
        }

        return valorHora;
    }

    public static (int horasCheias, int minutosRestantes) SepararHorasMinutos(int totalMinutos) {
        return (totalMinutos / 60, totalMinutos % 60);
    }

    public static string ConverterDuracaoHorasMinutos(int totalMinutos) {
        var (horasCheias, minutosRestantes) = SepararHorasMinutos(totalMinutos);
        return $"{horasCheias}h {minutosRestantes}min";
    }

    public static int CalcularHorasCobradas(int totalMinutos) {
        var (horasCheias, minutosRestantes) = SepararHorasMinutos(totalMinutos);
        return minutosRestantes > 0 ? horasCheias + 1 : horasCheias;
    }

    public static double CalcularTarifa(int totalMinutos, double valorHora) {
        return CalcularHorasCobradas(totalMinutos) * valorHora;
    }

    public static string ClassificarPermanencia(int minutosEstacionado) {
        /*
        Limites escolhidos:
            - até 60 min = rotativa curta (1h, tempo comum de parada rápida para uma compra, um atendimento, etc.)
            - de 61 a 240 min = rotativa padrão (de 1 a 4h, tempo comum de permanência para uma atividade mais longa, como uma reunião, etc.)
            - acima de 240 min = diária (a partir de 4 horas, consideramos que o veículo permaneceu por um período equivalente a uma diária)
        */
        const int limiteRotativaCurta = 60;
        const int limiteRotativaPadrao = 240;

        if (minutosEstacionado <= limiteRotativaCurta) {
            return "rotativa curta";
        }

        if (minutosEstacionado <= limiteRotativaPadrao) {
            return "rotativa padrão";
        }

        return "diária";
    }
}
