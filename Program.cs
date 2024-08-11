using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

ReservaManager reservaManager = new ReservaManager();

//Lê os nomes e insere na lista de hospedes
reservaManager.CadastrarHospedesReserva();

// (Exibe suítes, seleciona suítes e calcula os valores da reserva)
reservaManager.ProcessarReserva();



