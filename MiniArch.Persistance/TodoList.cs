//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniArch.Persistance
{
	using System.Collections.Generic;
    
    public partial class TodoList
    {
        public TodoList()
        {
            this.TodoListItems = new HashSet<TodoListItem>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<TodoListItem> TodoListItems { get; set; }
    }
}
