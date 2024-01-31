﻿using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Database;

public class AppDbContext : DbContext
{

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	public DbSet<Product> Products { get; set; }



}
