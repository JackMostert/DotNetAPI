﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
  public class Order
  {
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    [JsonIgnore]
    public virtual List<Product> Products { get; set; }
  }
}