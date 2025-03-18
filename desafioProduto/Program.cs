using System;
using System.Security.Cryptography.X509Certificates;
using desafioProduto.models;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace Program
{
    class Program
    {
        private static string caminhoArquivo = Path.Combine(Environment.CurrentDirectory, "Produtos.xlsx");
        public static List<Produto> produtos = [];
        static void Main()
        {
            ImportarDadosPlanilha();
            //exercicioUm();
            //exercicioDois();
            //exercicioTres();
            //exercicioQuatro();
            //exercicioCinco();
            //exercicioSeis();
            
           
        }
        public static void ImportarDadosPlanilha()
        {
            try
            {
                IWorkbook pastaDesafio = WorkbookFactory.Create(caminhoArquivo);
                ISheet planilha = pastaDesafio.GetSheetAt(0);

                for(int i = 1; i < planilha.PhysicalNumberOfRows; i++)
                {
                    IRow linha = planilha.GetRow(i);

                    int codigo = (int)linha.GetCell(0).NumericCellValue;
                    string nome = linha.GetCell(1).StringCellValue;
                    string categoria = linha.GetCell(2).StringCellValue;
                    string fabricante = linha.GetCell(3).StringCellValue;
                    double preco = linha.GetCell(4).NumericCellValue;
                    int quantidade = (int)linha.GetCell(5).NumericCellValue;
                    DateTime dataEntrada = linha.GetCell(1).DateCellValue ?? DateTime.Now;
                    string nomeEmpresa = linha.GetCell(7).StringCellValue;

                    Produto produto = new(codigo, nome, categoria, fabricante, preco, quantidade, dataEntrada, nomeEmpresa);
                    produtos.Add(produto);
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        
        }
    //1. Qual é o produto mais caro do estoque? (0,5)
    // Exemplo de saída esperada: O produto mais caro é o Parabrisa Ford Fusion, 
    // custando R$ 1.200.
        // public static void exercicioUm()
        // {
        //    var prodMaisCaro = produtos
        //     .OrderByDescending(p => p.Preco)
        //     .Take(1)
        //     .ToList();
        //     foreach (var item in prodMaisCaro)
        //     {
        //         Console.WriteLine($"O produto mais caro é o {item.Nome}, custando R$ {item.Preco:N2}.");
        //     }
        // }
    // 2. Quantos produtos com nomes diferentes há no estoque? (0,5)
    // Exemplo de saída esperada: Temos 50 produtos com nomes diferentes 
    // disponíveis em nosso catálogo.
        // public static void exercicioDois()
        // {
        //     var prodDiferente = produtos
        //     .Select(s => s.Nome).OrderBy(o => o).Distinct().ToList();
        //     Console.WriteLine($"Temos {prodDiferente.Count} produtos com nomes diferentes no estoque.");
        // }
    // 3. Quantos produtos entraram no estoque por mês? Faça uma lista 
    // ordenada ascendente dos meses e as respectivas quantidades. (0,5)
    // Exemplo de saída esperada:
    // - janeiro/2025: 20 unidades
    // - fevereiro/2025: 45 unidades
    // - março/2025: 12 unidades        
        // public static void exercicioTres()
        // {
        //     Console.Clear();
        //     var produtosPorMes = produtos
        //     .GroupBy(g => new 
        //     {
        //         Mes = g.DataEntrada.Month,
        //         Ano = g.DataEntrada.Year,
        //         Formato = g.DataEntrada.ToString("MMMM/yyyy")
        //     })
        //     .OrderBy(o => o.Key.Ano)
        //     .ThenBy(o => o.Key.Mes)
        //     .Select(s => new 
        //     {
        //         s.Key.Formato,
        //         Quantidade = s.Count()
        //     })
        //     .ToList();
        //     foreach (var produto in produtosPorMes)
        //     {
        //         Console.WriteLine($"{produto.Formato}: {produto.Quantidade} unidades.");
        //     }
        //     Console.ReadKey(); 
        // } 
    // 4. Crie um ranking
    // a. das 5 categorias com mais produtos em estoque. (0,4)
    // Exemplo de saída esperada:
    // - 1° Lugar: Vidros – 200 unidades
    // - 2° Lugar: Lanternas – 120 unidades
    // b. dos 3 centros de distribuição com mais estoque. (0,2)
    // Exemplo de saída esperada:
    // - 1° Lugar: Filial RJ – 95 unidades
    // - 2° Lugar: Filial SP – 80 unidades
    // c. dos 5 produtos que mais possuem estoque. (0,4)
    // Exemplo de saída esperada:
    // - 1° Lugar: Farol Principal Volkswagen Voyage – 55 unidades
    // - 2° Lugar: Para-choque Dianteiro – 20 unidades

        // public static void exercicioQuatro()
        // {
        //         var maisCategorias = produtos.GroupBy(g => g.Categoria)
        //     .Select(s => new
        //         {
        //             s.Key,
        //             quantidade = s.Sum(p => p.Quantidade)
        //         })
        //     .OrderByDescending(d => d.quantidade) 
        //     .Take(5) 
        //     .ToList();
        //         Console.WriteLine("Top 5 categorias com mais produtos em estoque:\n");
        //         for (int i = 0; i < maisCategorias.Count; i++)
        //         {
        //             Console.WriteLine($"{i + 1}° Lugar: {maisCategorias[i].Key} – {maisCategorias[i].quantidade} unidades");
        //         }

        //     Console.WriteLine(); 

        // Etapa b: Ranking dos 3 centros de distribuição com mais estoque
        //     var maisCentrosDistribuicao = produtos.GroupBy(g => g.NomeEmpresa)
        //     .Select(s => new
        //     {
        //         s.Key,
        //         quantidade = s.Sum(p => p.Quantidade)
        //     })
        //         .OrderByDescending(d => d.quantidade)
        //         .Take(3)
        //         .ToList();

        //     Console.WriteLine("Top 3 centros de distribuição com mais produtos em estoque:\n");
        //     for (int i = 0; i < maisCentrosDistribuicao.Count; i++)
        //     {
        //         Console.WriteLine($"{i + 1}° Lugar: {maisCentrosDistribuicao[i].Key} – {maisCentrosDistribuicao[i].quantidade} unidades");
        //     }

        //     Console.WriteLine();

        // E  tapa c: Ranking dos 5 produtos com mais estoque
        //      var maisProdutos = produtos.OrderByDescending(p => p.Quantidade)
        //     .Take(5)
        //     .ToList();

        //     Console.WriteLine("Top 5 produtos com mais estoque:\n");
        //     for (int i = 0; i < maisProdutos.Count; i++)
        //     {
        //         Console.WriteLine($"{i + 1}° Lugar: {maisProdutos[i].Nome} – {maisProdutos[i].Quantidade} unidades");
        //     }


        // }
    //  5. Em relação aos fabricantes, quantos temos em nossa base? Crie um 
    // ranking dos 5 fabricantes com mais itens em estoque. (0,5)
    // Exemplo de saída esperada:
    // Temos 10 fabricantes cadastrados em nossa base.
    // - 1° Lugar: AGC – 85 unidades
    // - 2° Lugar: Fanavid – 55 unidades
    // - 3° Lugar: Nakata – 20 unidades
        
    //     public static void exercicioCinco()
    //     {
    //         var rankingFabricantes = produtos.GroupBy(p => p.Fabricante)
    //         .Select(f => new
    //             {
    //                 Fabricante = f.Key,
    //                 Quantidade = f.Sum(p => p.Quantidade) 
    //             })
    //         .OrderByDescending(f => f.Quantidade) 
    //         .Take(5)
    //         .ToList();

    // total de  fabricantes
    //         Console.WriteLine($"Temos {rankingFabricantes.Count} fabricantes cadastrados em nossa base.\n");

     // Exibe o ranking dos 5 fabricantes
    //         Console.WriteLine("Ranking dos 5 fabricantes com mais itens em estoque:\n");
    //         for (int i = 0; i < rankingFabricantes.Count; i++)
    //         {
    //             Console.WriteLine($"{i + 1}° Lugar: {rankingFabricantes[i].Fabricante} - {rankingFabricantes[i].Quantidade} unidades");
    //         }
    //     }

    //     public static void exercicioSeis()
    //     {
    //         var produtosValorTotal = produtos.Select(p => new
    //         {
    //             p.Nome,
    //             p.Preco,
    //             p.Quantidade,
    //             ValorTotal = p.Preco * p.Quantidade
    //         })
    //         .OrderByDescending(p => p.ValorTotal)
    //         .Take(5)
    //         .ToList();

    //Exibe os produtos com maior valor total em estoque
    //         Console.WriteLine("Top 5 produtos com maior valor total em estoque:\n");
    //         foreach (var produto in produtosValorTotal)
    //         {
    //             Console.WriteLine($"{produto.Nome} – R$ {produto.ValorTotal} ({produto.Quantidade}un x R$ {produto.Preco:c})");
    //         }
    //     }
        
            

    }
}
