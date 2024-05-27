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

        public ItensReqService(IItensReqRepository pItensReqRepository)
        {
            _itensReqRepository = pItensReqRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensReq, ItensReqGetDTO>();
                cfg.CreateMap<ItensReqGetDTO, ItensReq>();
            });
        }

        public List<ItensReqGetDTO> ObterTodosItensReq()
        {
            var mapper = configurationMapper.CreateMapper();


            return  mapper.Map<List<ItensReqGetDTO>>(_itensReqRepository.ObterTodosItensReq());
        }

        public ItensReq ObterItensReqPorId(int id)
        {
            

            return _itensReqRepository.ObterItensReqPorId(id);
        }

        public ItensReqGetDTO CriarItensReq(ItensReqPostDTO itensReq)
        {
           var itensReqSalvo = _itensReqRepository.CriarItensReq(
                new ItensReq {
                    IdPro = itensReq.IdPro,
                    IdReq = itensReq.IdReq,
                    IdSec = itensReq.IdSec,
                    QtdPro = itensReq.QtdPro,
                    PreUnit = itensReq.PreUnit,
                    TotalItem = itensReq.TotalItem,
                    TotalReal = itensReq.TotalReal
                }
             );

            return new ItensReqGetDTO {
                NumItem = itensReqSalvo.NumItem,
                IdPro = itensReqSalvo.IdPro,
                IdReq = itensReqSalvo.IdReq,
                IdSec = itensReqSalvo.IdSec,
                QtdPro = itensReqSalvo.QtdPro,
                PreUnit = itensReqSalvo.PreUnit,
                TotalItem = itensReqSalvo.TotalItem,
                TotalReal = itensReqSalvo.TotalReal
            };
        }

    }
}
