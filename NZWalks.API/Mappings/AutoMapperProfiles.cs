﻿using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
	public class AutoMapperProfiles : Profile
	{
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
			CreateMap<UpdateRegionRequestDto, RegionDto>().ReverseMap();

			CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
			CreateMap<Walk,WalkDto>().ReverseMap();

		}
	}
}
