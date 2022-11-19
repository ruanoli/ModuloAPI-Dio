using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModuloAPI_Dio.Models;

namespace ModuloAPI_Dio.Context
{
    //conexão com o banco é feita através dessa nossa classe de contexto.
    public class AppAgendaDbContext : DbContext
    {
        public AppAgendaDbContext(DbContextOptions<AppAgendaDbContext> options) : base(options)
        {

        }

        //cria uma tabela no banco através da classe.
        public DbSet<Contato> Contatos {get; set;}
    }
}