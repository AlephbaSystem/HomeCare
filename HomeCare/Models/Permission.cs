using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Models
{
    public class Permission
    {
        public string Code { get; set; }
        public string Text { get; set; }

        public static List<Permission> GetAll()
        {
            var p = new List<Permission>();
            p.Add(new Permission() { Code = "A", Text = "امکان فعال و غیرفعال کردن و دریافت پیامک از دستگاه" });
            p.Add(new Permission() { Code = "B", Text = "امکان فعال و غیرفعال کردن و دریافت تماس از دستگاه" });
            p.Add(new Permission() { Code = "C", Text = "امکان فعال و غیرفعال کردن و ویرایش تنظیمات دستگاه" });
            p.Add(new Permission() { Code = "D", Text = "فقط امکان کنترل رله ها" });
            p.Add(new Permission() { Code = "E", Text = "امکان فعال و غیرفعال کردن و دریافت پیامک و تماس از دستگاه" });
            p.Add(new Permission() { Code = "F", Text = "دسترسی کامل به تمام امکانات" });
            p.Add(new Permission() { Code = "G", Text = "امکان فعال و غیرفعال کردن و دریافت پیامک و تماس و ویرایش تنظیمات دستگاه" });
            p.Add(new Permission() { Code = "H", Text = "امکان فعال و غیرفعال کردن و دریافت پیامک و تماس و امکان کنترل رله ها" });
            p.Add(new Permission() { Code = "I", Text = "امکان فعال و غیرفعال کردن و ویرایش تنظیمات دستگاه و امکان کنترل رله ها" });
            p.Add(new Permission() { Code = "J", Text = "امکان فعال و غیرفعال کردن و دریافت پیامک و ویرایش تنظیمات دستگاه و امکان کنترل رله ها" });
            p.Add(new Permission() { Code = "K", Text = "امکان فعال و غیرفعال کردن و دریافت تماس و ویرایش تنظیمات دستگاه و امکان کنترل رله ها" });
            p.Add(new Permission() { Code = "M", Text = "امکان فعال و غیرفعال کردن و دریافت پیامک و امکان کنترل رله ها" });
            p.Add(new Permission() { Code = "N", Text = "امکان فعال و غیرفعال کردن و دریافت تماس و امکان کنترل رله ها" });
            p.Add(new Permission() { Code = "O", Text = "امکان فعال و غیرفعال کردن و دریافت پیامک و ویرایش تنظیمات دستگاه" });
            p.Add(new Permission() { Code = "P", Text = "امکان فعال و غیرفعال کردن و دریافت تماس و ویرایش تنظیمات دستگاه" });
            p.Add(new Permission() { Code = "Q", Text = "فقط امکان فعال و غیرفعال کردن" });
            p.Add(new Permission() { Code = "R", Text = "فقط امکان غیرفعال کردن" });
            p.Add(new Permission() { Code = "S", Text = "فقط امکان فعال کردن" });
            p.Add(new Permission() { Code = "T", Text = "فقط دریافت پیامک و تماس" });
            return p;
        }
    }
}
