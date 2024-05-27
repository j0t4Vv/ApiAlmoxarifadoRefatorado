using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public RequisicaoRepository(xAlmoxarifadoContext pContext)
        {
            _context = pContext;
        }

        public List<Requisicao> ObterTudoRequisicao()
        {
            return _context.Requisicoes
                    .Select(requisicao => new Requisicao
                    {
                        IdReq = requisicao.IdReq,
                        IdCli = requisicao.IdCli,
                        TotalReq = requisicao.TotalReq,
                        QtdIten = requisicao.QtdIten,
                        DataReq = requisicao.DataReq,
                        Ano = requisicao.Ano,
                        Mes = requisicao.Mes,
                        IdSec = requisicao.IdSec,
                        IdSet = requisicao.IdSet,
                        Observacao = requisicao.Observacao
                    })
                    .ToList();
        }

        public Requisicao ObterRequisicaoPorId(int id)
        {
            return _context.Requisicoes
                   .Select(requisicao => new Requisicao
                   {
                       IdReq = requisicao.IdReq,
                       IdCli = requisicao.IdCli,
                       TotalReq = requisicao.TotalReq,
                       QtdIten = requisicao.QtdIten,
                       DataReq = requisicao.DataReq,
                       Ano = requisicao.Ano,
                       Mes = requisicao.Mes,
                       IdSec = requisicao.IdSec,
                       IdSet = requisicao.IdSet,
                       Observacao = requisicao.Observacao
                   })
                   .ToList().FirstOrDefault(x => x?.IdReq == id);
        }

        public Requisicao CriarRequisicao(Requisicao requisicao)
        {
            _context.Requisicoes.Add(requisicao);
            _context.SaveChanges();

            return requisicao;
        }

        public Requisicao AtualizarRequisicao(Requisicao requisicao)
        {
            var requisicaoExistente = _context.Requisicoes.FirstOrDefault(r => r.IdReq == requisicao.IdReq);
            if (requisicaoExistente != null)
            {
                requisicaoExistente.IdCli = requisicao.IdCli;
                requisicaoExistente.TotalReq = requisicao.TotalReq;
                requisicaoExistente.QtdIten = requisicao.QtdIten;
                requisicaoExistente.DataReq = requisicao.DataReq;
                requisicaoExistente.Ano = requisicao.Ano;
                requisicaoExistente.Mes = requisicao.Mes;
                requisicaoExistente.IdSec = requisicao.IdSec;
                requisicaoExistente.IdSet = requisicao.IdSet;
                requisicaoExistente.Observacao = requisicao.Observacao;
                _context.SaveChanges();
                return requisicaoExistente;
            }
            else
            {
                throw new InvalidOperationException("Requisição não encontrada!");
            }
        }

        public Requisicao ExcluirRequisicao(Requisicao requisicao)
        {
            var requisicaoExcluida = _context.Requisicoes.Remove(requisicao);
            _context.SaveChanges();
            return requisicaoExcluida.Entity;
        }
    }
}
