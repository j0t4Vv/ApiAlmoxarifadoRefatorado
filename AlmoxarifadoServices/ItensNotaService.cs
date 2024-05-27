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
        public ItensNotaGetDTO AtualizarItensNota(int id, ItensNotaPutDTO novoItemNota)
        {
            var itemNotaExistente = _itensNotaRepository.ObterItensNotaPorId(id);
            if (itemNotaExistente != null)
            {
                itemNotaExistente.IdPro = novoItemNota.IdPro;
                itemNotaExistente.IdNota = novoItemNota.IdNota;
                itemNotaExistente.IdSec = novoItemNota.IdSec;
                itemNotaExistente.QtdPro = novoItemNota.QtdPro;
                itemNotaExistente.PreUnit = novoItemNota.PreUnit;
                itemNotaExistente.TotalItem = novoItemNota.TotalItem;
                itemNotaExistente.EstLin = novoItemNota.EstLin;

                _itensNotaRepository.AtualizarItemNota(itemNotaExistente);

                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<ItensNotaGetDTO>(itemNotaExistente);
            }
            else
            {
                return null;
            }
        }

        public ItensNotaGetDTO ExcluirItensNota(ItensNota id)
        {
            var itemNotaExcluido = _itensNotaRepository.ExcluirItemNota(id);
            if (itemNotaExcluido != null)
            {
                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<ItensNotaGetDTO>(itemNotaExcluido);
            }
            return null;
        }
    }
}
