using System.Collections;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {

        public int DiasReservados { get; private set; }
        private List<Pessoa> Hospedes { get; set; }
        private Suite Suite { get; set; }
        
        public Reserva() { }

        public Reserva(int diasReservados) : this ()
        {
            DiasReservados = diasReservados; 
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            //Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite == null)
            {
                throw new InvalidOperationException("Não é possível cadastrar hóspedes sem uma suíte. ");
            }

            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException("A capacidade da suíte é menor que a quantidade de hóspedes.");
            }
        }
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            //Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;   
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Não é possível calcular o valor da diária sem uma suíte. ");
            }
            //Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor += 0.90m; // 10% de desconto
            }

            return valor;
        }
    }
    
}