using System;

namespace Ruan_Silva_DR2_TP1.Exercicio6.ClassificadorPermanencia;

public class Program {
    public static void Main() {
        /*
        Limites escolhidos:
            - até 60 min = rotativa curta (1h, tempo comum de parada rápida para uma compra, um atendimento, etc.)
            - de 61 a 240 min = rotativa padrão (de 1 a 4h, tempo comum de permanência para uma atividade mais longa, como uma reunião, etc.)
            - acima de 240 min = diária (a partir de 4 horas, consideramos que o veículo permaneceu por um período equivalente a uma diária)
        */
        const int limiteRotativaCurta = 60;
        const int limiteRotativaPadrao = 240;
        const int valorSentinela = -1;

        int contadorRotativaCurta = 0;
        int contadorRotativaPadrao = 0;
        int contadorDiaria = 0;

        while (true) {
            Console.Write("Informe o total de minutos estacionado (-1 para encerrar): ");
            string entradaMinutos = Console.ReadLine();

            if (!int.TryParse(entradaMinutos, out int minutosEstacionado)) {
                Console.WriteLine("Entrada inválida. Informe um número inteiro de minutos.");
                continue;
            }

            if (minutosEstacionado == valorSentinela) {
                break;
            }

            if (minutosEstacionado < 0) {
                Console.WriteLine("Erro: o total de minutos estacionado não pode ser negativo (use -1 para encerrar).");
                continue;
            }

            if (minutosEstacionado <= limiteRotativaCurta) {
                Console.WriteLine($"Permanência de {minutosEstacionado} min classificada como: rotativa curta");
                contadorRotativaCurta++;
            } else if (minutosEstacionado <= limiteRotativaPadrao) {
                Console.WriteLine($"Permanência de {minutosEstacionado} min classificada como: rotativa padrão");
                contadorRotativaPadrao++;
            } else {
                Console.WriteLine($"Permanência de {minutosEstacionado} min classificada como: diária");
                contadorDiaria++;
            }
        }

        int totalVeiculos = contadorRotativaCurta + contadorRotativaPadrao + contadorDiaria;

        Console.WriteLine();
        Console.WriteLine($"Rotativa curta: {contadorRotativaCurta}");
        Console.WriteLine($"Rotativa padrão: {contadorRotativaPadrao}");
        Console.WriteLine($"Diária: {contadorDiaria}");
        Console.WriteLine($"Total de veículos: {totalVeiculos}");
    }
}
