using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class ItensReqService
    {
        private readonly IItensReqRepository _itensReqRepository;
        private readonly MapperConfiguration configurationMapper;

        public ItensReqService(IItensReqRepository itensReqRepository)
        {
            _itensReqRepository = itensReqRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensReq, ItensReqGetDTO>();
                cfg.CreateMap<ItensReqGetDTO, ItensReq>();
            });
        }

        public List<ItensReqGetDTO> ObterTodosItensReq()
        {
            var mapper = configurationMapper.CreateMapper();
            return mapper.Map<List<ItensReqGetDTO>>(_itensReqRepository.ObterTodosItensReq());
        }

        public ItensReq ObterItensReqPorId(int id)
        {
            return _itensReqRepository.ObterItensReqPorId(id);
        }

        public ItensReqGetDTO CriarItensReq(ItensReqPostDTO itensReq)
        {
            var itemSalvo = _itensReqRepository.CriarItensReq(
                new ItensReq
                {
                    IdPro = itensReq.IdPro,
                    IdReq = itensReq.IdReq,
                    IdSec = itensReq.IdSec,
                    QtdPro = itensReq.QtdPro,
                    PreUnit = itensReq.PreUnit,
                    TotalItem = itensReq.QtdPro * itensReq.PreUnit,
                    TotalReal = itensReq.QtdPro * itensReq.PreUnit
                });
            return new ItensReqGetDTO
            {
                NumItem = itemSalvo.NumItem,
                IdPro = itemSalvo.IdPro,
                IdReq = itemSalvo.IdReq,
                IdSec = itemSalvo.IdSec,
                QtdPro = itemSalvo.QtdPro,
                PreUnit = itemSalvo.PreUnit,
                TotalItem = itemSalvo.QtdPro * itemSalvo.PreUnit,
                TotalReal = itemSalvo.QtdPro * itemSalvo.PreUnit
            };
        }
        public ItensReqGetDTO AtualizarItensReq(int id, ItensReqPutDTO novoItemReq)
        {
            var itemReqExistente = _itensReqRepository.ObterItensReqPorId(id);
            if (itemReqExistente != null)
            {
                itemReqExistente.IdPro = novoItemReq.IdPro;
                itemReqExistente.IdReq = novoItemReq.IdReq;
                itemReqExistente.IdSec = novoItemReq.IdSec;
                itemReqExistente.QtdPro = novoItemReq.QtdPro;
                itemReqExistente.PreUnit = novoItemReq.PreUnit;
                itemReqExistente.TotalItem = novoItemReq.QtdPro * novoItemReq.PreUnit;
                itemReqExistente.TotalReal = novoItemReq.QtdPro * novoItemReq.PreUnit;

                _itensReqRepository.AtualizarItensReq(itemReqExistente);

                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<ItensReqGetDTO>(itemReqExistente);
            }
            else
            {
                return null;
            }
        }


        public ItensReqGetDTO ExcluirItensReq(ItensReq itensReq)
        {
            var itemExcluido = _itensReqRepository.ExcluirItensReq(itensReq);
            if (itemExcluido != null)
            {
                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<ItensReqGetDTO>(itemExcluido);
            }
            return null;
        }
    }
}