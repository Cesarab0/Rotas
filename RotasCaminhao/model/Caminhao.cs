using System;
using System.Collections.Generic;

namespace Model
{
    public class Caminhao
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Motorista { get; set; }

        public double Faturamento { get; set; }

        public double Total_valor { get; set; }

        public static List<Caminhao> Caminhoes { get; set; } = new List<Caminhao>();

        public Caminhao(int id, string placa, string motorista)
        {
            this.Id = id;
            this.Placa = placa;
            this.Motorista = motorista;
            this.Faturamento = 0;
            this.Total_valor = 0;

            Caminhoes.Add(this);
           
        }

        public override string ToString()
        {
            return $"Id: {Id}, Placa: {Placa}, Motorista: {Motorista}, total rotas: {Faturamento}, total ganho: {Total_valor} ";
        }

        public static void AlterarCaminhao(
            int id,
            string placa,
            string motorista
        )
        {
            Caminhao caminhao = BuscarCaminhao(id);
            caminhao.Placa = placa;
            caminhao.Motorista = motorista;
        }

        public static void ExcluirCaminhao(int id)
        {
            Caminhao caminhao = BuscarCaminhao(id);
            Caminhoes.Remove(caminhao);
        }

        public static Caminhao BuscarCaminhao(int id)
        {
            Caminhao? caminhao = Caminhoes.Find(c => c.Id == id);
            if (caminhao == null) {
                throw new Exception("Caminhão não encontrado");
            }

            return caminhao;
        }
    }
}