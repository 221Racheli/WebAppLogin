﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO;

public partial class OrderItemDTO
{
    //public int Id { get; set; }

    //public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }
}
