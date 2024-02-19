using System;
using CheckPoint.Enums;
using CheckPoint.Models;

public class User {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public EnumPermission Permission {get;set;}
        
        public User(){}
        
        public User(string name, string gender, DateTime dateOfBirth, string address, string telephone, string email, string password)
        {
                this.Name = name;
                this.Gender = gender;
                this.DateOfBirth = dateOfBirth;
                this.Address = address;
                this.Telephone = telephone;
                this.Email = email;
                this.Password = password;
        }
        
        public User(int id, string name, string gender, DateTime dateOfBirth, string address, string telephone, string permission, string email, string password)
        {
                this.Id = id;
                this.Name = name;
                this.Gender = gender;
                this.DateOfBirth = dateOfBirth;
                this.Address = address;
                this.Telephone = telephone;
                this.Permission = (EnumPermission) Enum.Parse(typeof(EnumPermission), permission, true);
                this.Email = email;
                this.Password = password;
        }
        
        public void ApproveOrDisapproveComment(Comment comment)
        {
                if(comment.Status)
                {
                        comment.Status = false;
                
                }else
                {
                        comment.Status = true;
                }
        }
}