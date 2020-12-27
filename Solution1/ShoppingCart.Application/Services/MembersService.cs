using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class MembersService : IMembersService
    {
        private IMembersRepository _memberrepo;
        public MembersService (IMembersRepository memberrepo)
        {
            _memberrepo = memberrepo;
        }
        public void AddMember(MemberViewModel m)
        {
            Member member = new Member()
            {
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email
            };
            _memberrepo.AddMember(member);
        }
    }
}
