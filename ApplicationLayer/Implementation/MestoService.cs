﻿using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementation
{
    public class MestoService : IMestoService
    {
        private readonly IUnitOfWork unit;
        private readonly Mapper mapper;
        //private readonly MestoValidator validator;

        public MestoService(IUnitOfWork unit)
        {
            this.unit = unit;
            this.mapper = new Mapper();
            //this.validator = new MestoValidator();
        }

        public void DeleteById(long id)
        {
            Mesto mesto = unit.MestoRepository.Get(id);
            //validator.ValidateNullOrEmpty(mesto);

            unit.MestoRepository.Delete(mesto);
            unit.SaveChanges();
        }

        public List<MestoDTO> GetAll()
        {
            List<Mesto> mesta = unit.MestoRepository.GetAll();
            List<MestoDTO> mestaDTO = new List<MestoDTO>();

            mesta.ForEach(m =>
            {
                mestaDTO.Add(mapper.MestoToDto(m));
            });

            return mestaDTO;
        }

        public MestoDTO GetById(long id)
        {
            Mesto mesto = unit.MestoRepository.Get(id);
            //validator.ValidateNullOrEmpty(mesto);

            return mapper.MestoToDto(mesto);
        }

        public MestoDTO Save(MestoDTO dto)
        {
            //validator.ValidateNullOrEmpty(dto);
            //validator.ValidateForSave(dto);

            Mesto mesto = mapper.DtoToMesto(dto);
            unit.MestoRepository.Add(mesto);
            unit.SaveChanges();

            return dto;
        }

        public MestoDTO UpdateById(long id, MestoDTO dto)
        {
            Mesto mesto = unit.MestoRepository.Get(id);
            //validator.ValidateNullOrEmpty(mesto);

            //validator.ValidateNullOrEmpty(dto);
            //validator.ValidateForSave(dto);

            mesto.Naziv = dto.Naziv;
            mesto.BrojStanovnika = dto.BrojStanovnika;

            unit.MestoRepository.Update(mesto);
            unit.SaveChanges();

            return dto;
        }
    }
}
