﻿using Application.Features.ProductFeature.Commands;
using Application.Features.ProductFeature.Dtos;
using Application.Features.TestFeature.Commands;
using Application.Features.TestFeature.Dtos;
using AutoMapper;
using Domain.Common;
using Domain.Entities;

namespace Application.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Commands
            //Partie Add//
            CreateMap<AddProductCommandNew, Product>();
            //Partie Liste//
            CreateMap<PagedList<Product>, PagedList<ProductDTO>>().ReverseMap();

            //Dto
            CreateMap<Product, ProductDTO>().ReverseMap();

        }
    }
}
