﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace eVideoPrime.Core.Entities
{
    public partial class PaymentDetail
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Plan Plan { get; set; }
        public virtual User User { get; set; }
    }
}