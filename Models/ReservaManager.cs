using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models;
public class ReservaManager
{
    private List<Pessoa> hospedes;
    private List<Suite> suites;

    public ReservaManager()
    {
        hospedes = new List<Pessoa>();
        suites = new List<Suite>
        {
            new Suite(id: 1, tipoSuite: "Basic", capacidade: 2, valorDiaria: 30),
            new Suite(id: 2, tipoSuite: "Standard", capacidade: 3, valorDiaria: 50),
            new Suite(id: 3, tipoSuite: "Premium", capacidade: 4 , valorDiaria: 100),
            new Suite(id: 4, tipoSuite: "Master", capacidade: 6, valorDiaria: 150)
        };
    }

    public void CadastrarHospedesReserva()
    {
        string opcao = "S";

        do
        {
            Console.Write("Nome do Hóspede: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome)) continue;

            Pessoa novaPessoa = new Pessoa(nome);
            hospedes.Add(novaPessoa);

            Console.Write("Deseja cadastrar outra pessoa? (S/N) ");
            opcao = Console.ReadLine()?.ToUpper() ?? "N";
        } while (opcao == "S");


    }

    public void ExibirSuites()
    {
        Console.WriteLine("Suites Disponíveis: ");
        foreach (var suite in suites)
        {
            Console.WriteLine($"Id: {suite.Id} | Tipo: {suite.TipoSuite} | Capacidade: {suite.Capacidade} | Valor Diária: {suite.ValorDiaria}");
        }
    }

    public Suite SelecionarSuite()
    {
        int escolhaSuite;
        do
        {
            Console.Write("Insira o ID da Suíte que deseja, observando as condições de cada suíte: ");
            bool sucesso = int.TryParse(Console.ReadLine(), out escolhaSuite);
            
            if (!sucesso || escolhaSuite < 1 || escolhaSuite > suites.Count)
            {
                Console.WriteLine("ID Inválido. Tente Novamente. ");
                continue;
            }

            return suites.Find(s => s.Id == escolhaSuite);
        } while(true);
    } 

    public void ProcessarReserva()
    {
        ExibirSuites();
        Suite suiteEscolhida = SelecionarSuite();

        Console.Write("Por quantos dias gostaria de reservar? ");
        int diasReservados;
        
        while(!int.TryParse(Console.ReadLine(), out diasReservados) || diasReservados <= 0 )
        {
            Console.Write("Número de dias reservados inválido. Insira um valor positivo");
        }

        Reserva reserva = new Reserva(diasReservados);
        reserva.CadastrarSuite(suiteEscolhida);

        try
        {
            reserva.CadastrarHospedes(hospedes);

            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor Total: {reserva.CalcularValorDiaria():C}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"ERRO! {ex.Message}");
        }
    }
}
