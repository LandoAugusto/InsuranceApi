﻿namespace InsuranceApi.Core.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public int? Code { get; set; }
        public List<MenuModel>? MenuItem { get; set; } = [];
    }

    public class ListMenuModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<MenuModel>? Menus { get; set; } = [];
    }
}
