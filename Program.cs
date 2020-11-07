using System;
using CadastroIngredientes.db;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CadastroIngredientes
{
    class Program
    {
        static void Main(string[] args)
        {
            int tipoIng; 

            Console.WriteLine("Digite o nome do ingrediente: ");
            string nomeIng = Console.ReadLine();
            do {
                Console.WriteLine("Digite o tipo de ingrediente:\nSendo:\n-1- para Pão\n-2- para Carne\n-3- para Extra");
                tipoIng = int.Parse(Console.ReadLine());
                    if (tipoIng < 1 || tipoIng > 3) {
                        Console.WriteLine("Tipo inválido, tente novamente.");
                    };
            } while (tipoIng < 1 || tipoIng > 3);
            
            using (var db = new hamburgueriaContext())
            {
                var novoIng = new Ingrediente
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = nomeIng,
                    TipoIngredienteId = tipoIng,
                };

                db.Ingrediente.Add(novoIng);
                db.SaveChanges();
            }
        }
    }
}
