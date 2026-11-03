using System;

namespace Ruan_Silva_DR2_TP1.Exercicio5.ClassificadorPermanencia;

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

        Console.Write("Informe o total de minutos estacionado: ");
        string entradaMinutos = Console.ReadLine();

        if (!int.TryParse(entradaMinutos, out int minutosEstacionado)) {
            Console.WriteLine("Entrada inválida. Informe um número inteiro de minutos.");
            return;
        }

        if (minutosEstacionado < 0) {
            Console.WriteLine("Erro: o total de minutos estacionado não pode ser negativo.");
            return;
        }

        if (minutosEstacionado <= limiteRotativaCurta) {
            Console.WriteLine($"Permanência de {minutosEstacionado} min classificada como: rotativa curta");
        } else if (minutosEstacionado <= limiteRotativaPadrao) {
            Console.WriteLine($"Permanência de {minutosEstacionado} min classificada como: rotativa padrão");
        } else {
            Console.WriteLine($"Permanência de {minutosEstacionado} min classificada como: diária");
        }
    }
}
