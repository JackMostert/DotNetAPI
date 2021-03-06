﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Classes;
using WebApi.Models;

namespace WebApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class Products : Controller
  {
    private readonly ShopContext _context;

    public Products(ShopContext context)
    {
      _context = context;
      _context.Database.EnsureCreated();
    }

    [HttpGet, Route("/products")]
    public async Task<IActionResult> GetAllProducts([FromQuery] QueryParameters queryParameters)
    {
      IQueryable<Product> products = _context.Products;

      products = products.Skip(queryParameters.Size * (queryParameters.Page - 1)).Take(queryParameters.Size);

      return Ok(await products.ToArrayAsync());
    }

    [HttpGet, Route("/products/{id:int}")]
    public async Task<IActionResult> GetProduct(int id)
    {
      Product product = await _context.Products.FindAsync(id);

      if (product == null)
      {
        return NotFound();
      }

      return Ok(product);
    }
  }
}