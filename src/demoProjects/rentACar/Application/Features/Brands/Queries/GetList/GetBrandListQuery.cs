using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetBrandListQuery : IRequest<BrandListModel>
    {


        public PageRequest PageRequest { get; set; }
        public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, BrandListModel>
        {
            IBrandRepository _brandRepository;
            IMapper _mapper;

            public GetBrandListQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
            {
              IPaginate<Brand> brand = await  _brandRepository.GetListAsync(index: request.PageRequest.Page,size:request.PageRequest.PageSize);

                BrandListModel mappedBrandListModel =  _mapper.Map<BrandListModel>(brand);

                return mappedBrandListModel;
            }
        }
    }
}
