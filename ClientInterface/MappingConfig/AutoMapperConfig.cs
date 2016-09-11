using ClientInterface.Models;
using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientInterface.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void MapStudenToVM()
        {
            AutoMapper.Mapper.Initialize(abc => abc.CreateMap<Student, StudentsViewModel>().ForSourceMember(x => x.branch, t => t.Ignore()).ForSourceMember(x => x.AcademicYear, t => t.Ignore()).ReverseMap());
            //AutoMapper.Mapper.Initialize(abc => abc.CreateMap<StudentsViewModel,Student>());
        }

        public static void MapBranchBranchVM()
        {
            AutoMapper.Mapper.Initialize(abc => abc.CreateMap<Branch, BranchViewModel>().ReverseMap());
            //AutoMapper.Mapper.Initialize(abc => abc.CreateMap<BranchViewModel, Branch>());
        }

        public static void MapDocument_VM()
        {
            AutoMapper.Mapper.Initialize(abc => abc.CreateMap<DocumentLinks, DocumentViewModel>()
            .ForSourceMember(e => e.branch, t => t.Ignore())
            .ForSourceMember(e => e.academicYear, t => t.Ignore())
            .ForSourceMember(e => e.documentType, t => t.Ignore()).ReverseMap()
            );
        }
    }
}