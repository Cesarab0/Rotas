using Model;

namespace Controller
{
    public class Caminhao
    {
        private static void ValidaPlaca(
            string placa
        ) {
            string[] placaSplit = placa.Split('-');
            if (placaSplit.Length != 2) {
                throw new Exception("Placa inválida");
            }
            if (placaSplit[0].Length != 3) {
                throw new Exception("Placa inválida");
            }
            if (placaSplit[1].Length != 4) {
                throw new Exception("Placa inválida");
            }

            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "0123456789";

            foreach (char letra in placaSplit[0]) {
                if (!letras.Contains(letra.ToString())) {
                    throw new Exception("Placa inválida");
                }
            }

            foreach (char numero in placaSplit[1]) {
                if (!numeros.Contains(numero.ToString())) {
                    throw new Exception("Placa inválida");
                }
            }
        }

        public static void CadastrarCaminhao(
            string id,
            string placa,
            string motorista
        ) {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }

            ValidaPlaca(placa);
            Model.Caminhao caminhao = new Model.Caminhao(idConvert, placa, motorista);
        }

        public static void AlterarCaminhao(
            string id,
            string placa,
            string motorista
        ) {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            ValidaPlaca(placa);
            Model.Caminhao.AlterarCaminhao(idConvert, placa, motorista);
        }

        public static void ExcluirCaminhao(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Caminhao.ExcluirCaminhao(idConvert);
        }

        public static Model.Caminhao BuscarCaminhao(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Model.Caminhao.BuscarCaminhao(idConvert);
        }

        public static List<Model.Caminhao> ListarCaminhoes()
        {
            return Model.Caminhao.Caminhoes;
        }

        public static double total_rotas(int id) {
            double total = 0;
            foreach (Model.Rota rota in Model.Rota.Rotas) {
                if (rota.Caminhao.Id == id) {
                    total ++;
                }
            }
            return total;
        }

        public static double total_ganho(int id) {
            double total = 0;
            foreach (Model.Rota rota in Model.Rota.Rotas) {
                if (rota.Caminhao.Id == id) {
                    total += rota.Valor;
                }
            }
            return total;
        }
    }
}