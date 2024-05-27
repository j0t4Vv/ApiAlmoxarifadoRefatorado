using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class ItensNotaService
    {
        private readonly IItensNotaRepository _itensNotaRepository;
        private readonly MapperConfiguration configurationMapper;

        public ItensNotaService(IItensNotaRepository pItensNotaRepository)
        {
            _itensNotaRepository = pItensNotaRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensNota, ItensNotaGetDTO>();
                cfg.CreateMap<ItensNotaGetDTO, ItensNota>();
            });
        }

        public List<ItensNotaGetDTO> ObterTodosItensNota()
        {
            var mapper = configurationMapper.CreateMapper();

            return mapper.Map<List<ItensNotaGetDTO>>(_itensNotaRepository.ObterTodosItensNotas());
        }

        public ItensNota ObterItensNotaPorId(int id)
        {
            return _itensNotaRepository.ObterItensNotaPorId(id);
        }

        public ItensNotaGetDTO CriarItensNota (ItensNotaPostDTO itensNota)
        {
            var itensNotaSalvo = _itensNotaRepository.CriarItensNota(
                    new ItensNota
                    {
                        IdPro = itensNota.IdPro,
                        IdNota = itensNota.IdNota,
                        IdSec = itensNota.IdSec,
                        QtdPro = itensNota.QtdPro,
                        PreUnit = itensNota.PreUnit,
                        TotalItem = itensNota.TotalItem,
                        EstLin = itensNota.EstLin
                    }
                );

            return new ItensNotaGetDTO
            {
                ItemNum = itensNotaSalvo.ItemNum,
                IdPro = itensNotaSalvo.IdPro,
                IdNota = itensNotaSalvo.IdNota,
                IdSec = itensNotaSalvo.IdSec,
                QtdPro = itensNotaSalvo.QtdPro,
                PreUnit = itensNotaSalvo.PreUnit,
                TotalItem = itensNotaSalvo.TotalItem,
                EstLin = itensNotaSalvo.EstLin
            };
        }
    }
}
