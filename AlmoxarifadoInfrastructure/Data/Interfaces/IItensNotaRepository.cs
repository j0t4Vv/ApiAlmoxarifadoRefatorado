using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensNotaRepository
    {
        List<ItensNota> ObterTodosItensNotas();
        ItensNota ObterItensNotaPorId(int id);

        ItensNota CriarItensNota(ItensNota itensNota);
    }
}
