
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
               /* .ForMember(
                c => c.Id, opt => opt.Ignore());*/
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //domain to dto
            Mapper.CreateMap<Movie, MovieDto>();
                /*.ForMember(
                c => c.Id, opt => opt.Ignore()); */

            //dto to domain
            Mapper.CreateMap<MovieDto, Movie>();
        }

    }
}