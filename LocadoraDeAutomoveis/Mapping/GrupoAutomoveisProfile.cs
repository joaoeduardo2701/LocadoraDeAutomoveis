﻿using AutoMapper;
using LocadoraDeAutomoveis.WebApp.Models;

namespace LocadoraDeAutomoveis.WebApp.Mapping
{
	public class GrupoAutomoveisProfile : Profile
	{
		public GrupoAutomoveisProfile()
		{
			CreateMap<InserirGrupoAutomoveisViewModel, Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis>();
			CreateMap<EditarGrupoAutomoveisViewModel, Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis>();

			CreateMap<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis, EditarGrupoAutomoveisViewModel>();
			CreateMap<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis, ListarGrupoAutomoveisViewModel>();
			CreateMap<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis, DetalhesGrupoAutomoveisViewModel>();
		}
	}
}
