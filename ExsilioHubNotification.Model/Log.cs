//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExsilioHubNotification.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        public int LogId { get; set; }
        public System.DateTime Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}