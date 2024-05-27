using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface INotaFiscalRepository
    {
        List<NotaFiscal> ObterTodosNotaFiscal();
        NotaFiscal ObterNotaFiscalPorId(int id);
        NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal);
        NotaFiscal AtualizarNotaFiscal(NotaFiscal notaFiscal);
        NotaFiscal ExcluirNotaFiscal(NotaFiscal notaFiscal);
    }

}
