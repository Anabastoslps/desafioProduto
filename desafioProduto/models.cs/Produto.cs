
using System.Data;
using System.Dynamic;
using System.Xml.Serialization;

namespace desafioProduto.models;


    public class Produto{
        public int Codigo { get; protected set; }
        public string Nome { get; protected set; }
        public string Categoria { get; protected set; }
        public string Fabricante { get; protected set; }
        public double Preco { get; protected set; }
        public int Quantidade { get; protected set; }
        public DateTime DataEntrada { get; protected set; }
        public string NomeEmpresa { get; protected set; }

        public Produto
        (
            int codigo,
            string nome,
            string categoria,
            string fabricante,
            double preco,
            int quantidade,
            DateTime dataEntrada,
            string nomeEmpresa
        )
        {
            SetCodigo(codigo);
            SetNome(nome);
            SetCategoria(categoria);
            SetFabricante(fabricante);
            SetPreco(preco);
            SetQuantidade(quantidade);
            SetDataEntrada(dataEntrada);
            SetNomeEmpresa(nomeEmpresa);
        }

        public void SetCodigo(int codigo)
        {
            Codigo = codigo;
        }
        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto não pode estar vazio.");
            if (nome.Length> 255)
                throw new Exception("O nome do produto não poder ser mais do que 255 caracteres. ");   
            Nome = nome;
        }
        public void SetCategoria(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("A categoria do produto nao pode ser nula.");
            Categoria = categoria;
        }
        public void SetFabricante(string fabricante)
        {
            if (string.IsNullOrWhiteSpace(fabricante))
                throw new ArgumentException("O campo fabricante nao pode ser nulo.");
            Fabricante = fabricante;
        }
        public void SetPreco(double preco)
        {
            
             if (preco <= 0)
                throw new Exception("O Preço do produto deve ser maior que zero.");
            Preco = preco;
        }
        public void SetQuantidade(int quantidade)
        {
            if (quantidade < 0)
                throw new Exception("A Quantidade de produto não pode ser zero.");
            Quantidade = quantidade;    
            
        }
        public void SetDataEntrada(DateTime dataEntrada)
        {
            if (dataEntrada == DateTime.MinValue)
                throw new Exception("Data de entrada inválida.");
            DataEntrada = dataEntrada;
        }

        public void SetNomeEmpresa(string nomeEmpresa)
        {
            if (string.IsNullOrWhiteSpace(nomeEmpresa))
                throw new Exception("o nome da Empresa não pode estar vazia.");
            NomeEmpresa = nomeEmpresa;
        }

}
