using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado;

public static class VisualizacaoMedicamentos
{
    public static void Exibir(List<Medicamento> registros)
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -10}",
            "Id", "Nome", "Fornecedor", "Descrição", "Estoque"
        );

        foreach (Medicamento m in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -10}",
                m.Id, m.Nome, m.Fornecedor.Nome, m.Descricao, m.QuantidadeEmEstoque
            );

            if (m.QuantidadeEmEstoque <= 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Atenção: Estoque baixo!");
                Console.ResetColor();
            }
        }
    }
}
