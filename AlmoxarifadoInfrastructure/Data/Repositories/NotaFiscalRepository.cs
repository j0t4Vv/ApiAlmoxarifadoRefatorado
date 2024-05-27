using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public NotaFiscal AtualizarNotaFiscal(NotaFiscal notaFiscal)
        {
            var notaExistente = _context.NotasFiscais.FirstOrDefault(nota => nota.IdNota == notaFiscal.IdNota);
            if (notaExistente != null)
            {
                notaExistente.IdFor = notaFiscal.IdFor;
                notaExistente.IdSec = notaFiscal.IdSec;
                notaExistente.NumNota = notaFiscal.NumNota;
                notaExistente.ValorNota = notaFiscal.ValorNota;
                notaExistente.QtdItem = notaFiscal.QtdItem;
                notaExistente.Icms = notaFiscal.Icms;
                notaExistente.Iss = notaFiscal.Iss;
                notaExistente.Ano = notaFiscal.Ano;
                notaExistente.Mes = notaFiscal.Mes;
                notaExistente.DataNota = notaFiscal.DataNota;
                notaExistente.IdTipoNota = notaFiscal.IdTipoNota;
                notaExistente.ObservacaoNota = notaFiscal.ObservacaoNota;
                notaExistente.EmpenhoNum = notaFiscal.EmpenhoNum;

                _context.SaveChanges();
                return notaExistente;
            }
            else
            {
                throw new InvalidOperationException("Nota Fiscal não encontrada!");
            }
        }

        public NotaFiscal ExcluirNotaFiscal(NotaFiscal notaFiscal)
        {
            var notaFiscalComItens = _context.NotasFiscais
                .Include(notaFiscal => notaFiscal.ItensNota)
                .FirstOrDefault(notaFiscal => notaFiscal.IdNota == notaFiscal.IdNota);

            if (notaFiscalComItens != null)
            {
                _context.ItensNota.RemoveRange(notaFiscalComItens.ItensNota);
                _context.NotasFiscais.Remove(notaFiscalComItens);
                _context.SaveChanges();
            }
            return notaFiscal;
        }
    }
}
