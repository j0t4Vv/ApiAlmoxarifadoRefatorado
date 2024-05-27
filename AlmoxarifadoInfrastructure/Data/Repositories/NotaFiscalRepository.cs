using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public NotaFiscalRepository(xAlmoxarifadoContext pContext)
        {
            _context = pContext;
        }

        public List<NotaFiscal> ObterTodosNotaFiscal()
        {
            return _context.NotasFiscais
                   .Select(notaFiscal => new NotaFiscal
                   {
                       IdNota = notaFiscal.IdNota,
                       IdFor = notaFiscal.IdFor,
                       IdSec = notaFiscal.IdSec,
                       NumNota = notaFiscal.NumNota,
                       ValorNota = notaFiscal.ValorNota,
                       QtdItem = notaFiscal.QtdItem,
                       Icms = notaFiscal.Icms,
                       Iss = notaFiscal.Iss,
                       Ano = notaFiscal.Ano,
                       Mes = notaFiscal.Mes,
                       DataNota = notaFiscal.DataNota,
                       IdTipoNota = notaFiscal.IdTipoNota,
                       ObservacaoNota = notaFiscal.ObservacaoNota,
                       EmpenhoNum = notaFiscal.EmpenhoNum
                   })
                   .ToList();
        }

        public NotaFiscal ObterNotaFiscalPorId(int id)
        {
            return _context.NotasFiscais
                   .Select(notaFiscal => new NotaFiscal
                   {
                       IdNota = notaFiscal.IdNota,
                       IdFor = notaFiscal.IdFor,
                       IdSec = notaFiscal.IdSec,
                       NumNota = notaFiscal.NumNota,
                       ValorNota = notaFiscal.ValorNota,
                       QtdItem = notaFiscal.QtdItem,
                       Icms = notaFiscal.Icms,
                       Iss = notaFiscal.Iss,
                       Ano = notaFiscal.Ano,
                       Mes = notaFiscal.Mes,
                       DataNota = notaFiscal.DataNota,
                       IdTipoNota = notaFiscal.IdTipoNota,
                       ObservacaoNota = notaFiscal.ObservacaoNota,
                       EmpenhoNum = notaFiscal.EmpenhoNum
                   })
                   .ToList().First(x => x?.IdNota == id);
        }

        public NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Add(notaFiscal);
            _context.SaveChanges();

            return notaFiscal;
        }
    }
}
