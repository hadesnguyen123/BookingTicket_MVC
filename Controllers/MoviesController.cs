﻿using BookingTicket.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTicket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // bất đồng bộ, chờ kết quả trả về từ ToListAsync(), ko cần chặn luống ứng dụng
        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(x => x.Cinema).ToListAsync();
            return View(allMovies);
        }

        ////GET: Movies/Details/1
        //[AllowAnonymous]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var movieDetail = await _service.GetMovieByIdAsync(id);
        //    return View(movieDetail);
        //}
    }
}
