﻿using AutoMapper;
using BookEntities.BusinessEntities;
using BookService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreService
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}
