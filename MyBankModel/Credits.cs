//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBankModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Credits
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public System.DateTime Date { get; set; }
        public int Loan { get; set; }
        public string Target { get; set; }
        public string VipBonus { get; set; }
        public int ClientId { get; set; }
    }
}
